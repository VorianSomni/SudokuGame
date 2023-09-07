using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.XR;

public class SudokuCreation : MonoBehaviour
{
    public string SudokuGame;

    struct CreateSudokuGame : IJob
    {
        public float deltaTime;
        public NativeArray<byte> game;

        public void Execute()
        {
            int[,] board = new int[9, 9];
            GenerateSolvedSudoku(board);
            string newGame = CreateString(board);
            byte[] bytes = Encoding.ASCII.GetBytes(newGame);

            for (int i = 0; i < game.Length; i++)
            {
                game[i] = bytes[i];
            }

        }

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
    }


    public void CreateSudoku()
    {
        // Cria a variável para o job
        NativeArray<byte> BytesDoJob = new NativeArray<byte>(81, Allocator.TempJob);

        // Inicia o Job
        var job = new CreateSudokuGame()
        {
            deltaTime = Time.deltaTime,
            game = BytesDoJob
        };

        // marca e executa o Job
        JobHandle jobHandle = job.Schedule();
        jobHandle.Complete();

        // Agora temos o NativeArray<byte> game para lidar.
        // Passa o que o job criou para uma variável para utilizarmos.

        byte[] BytesArray = new byte[81];
        for (int i = 0; i < BytesDoJob.Length; i++)
        {
            BytesArray[i] = BytesDoJob[i];
        }

        // Temos que descarregar a variável do Job da memória
        BytesDoJob.Dispose();

        // Agora podemos tratar a varivável que o Job Trouxe
        SudokuGame = Encoding.UTF8.GetString(BytesArray);
        print(SudokuGame);
    }

    /* 
    Proximos passos:
    Preciso criar um job para criar o sudoku pela dificuldade
    Essa vai ser a parte mais difícil, mas nem tanto assim pois já temos o código necessário.
    Essa parte do Job foi interessante. Devo esquecer depois que voltar do RJ... Vou deixar aqui uns links:
    https://docs.unity3d.com/Manual/JobSystem.html
    https://www.youtube.com/watch?v=YBrCR9rUOaA
    https://gamedev.stackexchange.com/questions/200861/passing-a-string-as-argument-to-unity-job-system

    Vale a pena usar o Job? Acho que sim?
    Pelo menos ele vai criar multithreaths para computar nosso jogo.
    IEnumerator não cria multithreads! Que FDP.
    
    Jobs não podem usar IEnumerator.

    */
}
