using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing.MiniJSON;
using System.Text;
using System;

// Atenção. Esse script serve apenas para uso dos Desenvolvedores.
// Retirar qualquer meio do usuário acessar esse script no jogo final.


public class TxtTerrorGameCreator : MonoBehaviour
{
    
    int[,] JogoFinalizado;
    string newGame;
    System.Random rand = new System.Random();

    public void CreateTerrorTxt()
    {
        string path = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "TerrorGames.txt";
        if (!File.Exists(path))
        {
            var myfile = File.CreateText(path);
            myfile.Close();
        }

        for (int i = 0; i < 100; i++)
        {

            int[,] board = new int[9, 9];
            GenerateSolvedSudoku(board);
            JogoFinalizado = CreateGameByDificulty(board);
            newGame = CreateString(JogoFinalizado);

            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(newGame);
            };
        }
        print("Criados 100 jogos terror");
    }

    #region Nope
    
    public bool GenerateSolvedSudoku(int[,] board)
    {

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (board[i, j] == 0)
                {
                    
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

    public int[,] CreateGameByDificulty(int[,] matriz)
    {
        int random_num = 0;
        int[,] matriz_diff = new int[9, 9];
        Array.Copy(matriz, matriz_diff, matriz.Length);
        random_num = rand.Next(56, 58);
              

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
}
