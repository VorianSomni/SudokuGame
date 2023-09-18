using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Unity.Collections;
using Unity.Jobs;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class SudokuCreation : MonoBehaviour
{
    [SerializeField] GameVariables gameVariables;
    [SerializeField] TextAsset terrorGames;


    public void CreateSudoku(int dificuldade)
    {
        if(dificuldade == 5) // se for Terror
        {
            ChameJogosTerror();
            return;
        }

        int[,] board = new int[9,9];
        GenerateSolvedSudoku(board); // Gerou o jogo completo dentro de board
        gameVariables.AtualSudokuGameCompleto = CreateString(board);
        gameVariables.AtualSudokuGameIncompleto = CreateString(CreateGameByDificulty(board, dificuldade));
    }

    void ChameJogosTerror()
    {
        System.Random random = new System.Random();
        string[] lines;
        lines = terrorGames.text.Split('\n');

        gameVariables.AtualSudokuGameIncompleto = lines[random.Next(lines.Length)];
        gameVariables.AtualSudokuGameCompleto = SolveSudoku(gameVariables.AtualSudokuGameIncompleto);
    }

    #region Base do Sudoku

    public bool GenerateSolvedSudoku(int[,] board)
    {

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (board[i, j] == 0)
                {
                    System.Random rand = new System.Random();
                    List<int> nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                    int num = nums[rand.Next(nums.Count)];
                    for (int n = 1; n < 10; n++)
                    {
                        if (IsValid(board, num, i, j))
                        {
                            board[i, j] = num;
                            if (!GenerateSolvedSudoku(board))
                            {
                                board[i, j] = 0;
                            }
                            else
                            {
                                return true;
                            }
                        }
                        else
                        {
                            nums.Remove(num);
                        }
                    }
                    return false;
                }
            }
        }
        return true;
    }

    public int[,] CreateGameByDificulty(int[,] matriz, int difficulty)
    {
        System.Random rand = new System.Random();
        int random_num = 0;
        int[,] matriz_diff = new int[9, 9];
        Array.Copy(matriz, matriz_diff, matriz.Length);

        if (difficulty == 4)   // Expert
        {
            random_num = rand.Next(46, 55);
        }

        if (difficulty == 3)   // Hard
        {
            random_num = rand.Next(40, 45);
        }

        if (difficulty == 2)   // Medium
        {
            random_num = rand.Next(33, 39);
        }

        if (difficulty == 1)    // Easy
        {
            random_num = rand.Next(25, 32);
        }

        if (difficulty == 0)    // Novice
        {
            random_num = rand.Next(18, 24);
        }

        ZerosOnGrid(random_num, matriz_diff, matriz);

        return matriz_diff;
    }

    bool IsValid(int[,] board, int num, int row, int col)
    {
        for (int i = 0; i < 9; i++)
        {
            //check row  
            if (board[i, col] != 0 && board[i, col] == num)
                return false;
            //check column  
            if (board[row, i] != 0 && board[row, i] == num)
                return false;
            //check 3*3 block  
            if (board[3 * (row / 3) + i / 3, 3 * (col / 3) + i % 3] != 0 && board[3 * (row / 3) + i / 3, 3 * (col / 3) + i % 3] == num)
                return false;
        }
        return true;

    }

    public string CreateString(int[,] matriz)
    {
        var text = new System.Text.StringBuilder();
        foreach (var item in matriz)
        {
            text.Append(item.ToString());
        }
        return text.ToString();
    }

    public int[,] CreateMatriz(string game)
    {
        List<char> chars = new List<char>();
        for (int i = 0; i < game.Length; i++)
        {
            chars.Add(game[i]);
        }

        int[,] ints = new int[9, 9];
        int count = 0;
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                ints[i, j] = int.Parse(chars[count].ToString());
                count++;
            }

        }
        return ints;
    }

    public int solver(int[,] board, int count)
    { // Starts with count = 0
        int[,] board2 = new int[9, 9];

        for (int i = 0; i < 9; i++)
        { //GRID_SIZE = 9

            for (int j = 0; j < 9; j++)
            {

                /*
                 * Only empty fields will be changed
                 */

                if (board[i, j] == 0)
                { //EMPTY = 0

                    /*
                     * Try all numbers between 1 and 9
                     */

                    for (int n = 1; n <= 9 && count < 2; n++)
                    {

                        /*
                         * Is number n safe?
                         */
                        if (IsValid(board, n, i, j))
                        {

                            board[i, j] = n;
                            int cache = solver(board, count);
                            if (cache > count)
                            {
                                count = cache;
                                for (int k = 0; k < 9; k++)
                                {
                                    for (int l = 0; l < 9; l++)
                                    {
                                        if (board[k, l] != 0)
                                        {
                                            board2[k, l] = board[k, l];
                                        }

                                    }
                                }

                                board[i, j] = 0;

                            }
                            else
                            {
                                board[i, j] = 0;
                            }

                        }
                    }
                    return count;
                }
            }
        }
        return count + 1;
    }

    public int[,] ZerosOnGrid(int random_num, int[,] matriz_diff, int[,] matriz)
    {
        System.Random rand = new System.Random();
        int pos_x;
        int pos_y;
        int tries = 0;


        for (int i = 0; i < random_num; i++)
        {
            if (tries > 200)
            {
                break;
            }

            while (true)
            {
                pos_x = rand.Next(0, 9);
                pos_y = rand.Next(0, 9);
                if (matriz_diff[pos_x, pos_y] != 0)
                {
                    matriz_diff[pos_x, pos_y] = 0;
                    break;
                }
            }

            if (solver(matriz_diff, 0) > 1)
            {
                matriz_diff[pos_x, pos_y] = matriz[pos_x, pos_y];
                i--;
                tries++;
                continue;
            }

            tries = 0;
        }

        return matriz_diff;
    }

    #endregion

    #region Resolvedor de Sudoku

    static bool IsValidMove(string sudoku, int row, int col, char num)
    {
        for (int i = 0; i < 9; i++)
        {
            if (sudoku[row * 9 + i] == num || sudoku[i * 9 + col] == num)
                return false;
        }

        int boxStartRow = row - row % 3;
        int boxStartCol = col - col % 3;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (sudoku[(boxStartRow + i) * 9 + boxStartCol + j] == num)
                    return false;
            }
        }

        return true;
    }

    static string SolveSudoku(string sudoku)
    {
        int emptyCell = sudoku.IndexOf('0');

        if (emptyCell == -1)
            return sudoku; // Sudoku resolvido

        int row = emptyCell / 9;
        int col = emptyCell % 9;

        for (char num = '1'; num <= '9'; num++)
        {
            if (IsValidMove(sudoku, row, col, num))
            {
                char[] newSudoku = sudoku.ToCharArray();
                newSudoku[emptyCell] = num;
                string result = SolveSudoku(new string(newSudoku));
                if (!result.Contains('0'))
                    return result; // Sudoku resolvido
            }
        }

        return sudoku; // Nenhuma solução válida encontrada
    }

    #endregion
    
}
