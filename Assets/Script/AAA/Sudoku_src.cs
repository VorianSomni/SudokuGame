using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Threading;

// Essa classe deve apenas lidar com fun��es de gera��o de jogos Sudoku
// Mais do que isso � trazer problema para momentos posteriores.

// Usar uma Thread diferente da do jogo principal pode ajudar a reduzir problemas.

public class Sudoku_src : MonoBehaviour
{
    System.Random rand = new System.Random();
    public int[,] board2 = new int[9, 9];
    Color Sgray = new Color(50f / 255f, 50 / 255f, 50 / 255f, 255 / 255f);

    #region Tranformar Matriz para String e vice-versa
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
    #endregion


    public void ResetSquare(GameObject[,] grid)
    {
        foreach (var item in grid)
        {
            item.gameObject.GetComponent<Image>().color = Color.white;
            item.GetComponent<GridSquare>().number_text.fontStyle = FontStyles.Normal;
        }
    }

    public void ResetFont(GameObject[,] grid)
    {
        foreach (var item in grid)
        {
            item.gameObject.GetComponentInChildren<TextMeshProUGUI>().color = Sgray;
        }
    }

    public void FadePanel(bool in_out, CanvasGroup panel)
    {
        StartCoroutine(Fade(in_out, panel));
    }

    IEnumerator Fade(bool in_out, CanvasGroup panel)
    {
        if (in_out == true)
        {
            panel.interactable = true;
            panel.gameObject.SetActive(true);
            LeanTween.alphaCanvas(panel, 1, 0.5f);
        }
        else
        {
            panel.interactable = false;
            LeanTween.alphaCanvas(panel, 0, 0.5f);
            yield return new WaitForSeconds(0.6f);
            panel.gameObject.SetActive(false);
        }
        yield return null;
    }

    public void PencilColor(GameObject button, bool state)
    {
        if (state)
            button.GetComponent<Image>().color = Color.red;
        else
            button.GetComponent<Image>().color = Color.white;
    }

    public void ErasePencil(GameObject[] squares, int number)
    {
        foreach (var item in squares)
        {
            TextMeshProUGUI[] penciltexts = item.GetComponent<PencilTexts>().penciltexts;
            foreach (var penciltext in penciltexts)
            {
                if (penciltext.name == $"Pencil_text ({number})")
                {
                    penciltext.enabled = false;
                }
            }
        }
    }

    public void ErasePencil(GameObject[,] squares, int number)
    {
        foreach (var item in squares)
        {
            TextMeshProUGUI[] penciltexts = item.GetComponent<PencilTexts>().penciltexts;
            foreach (var penciltext in penciltexts)
            {
                if (penciltext.name == $"Pencil_text ({number})")
                {
                    penciltext.enabled = false;
                }
            }
        }
    }

    public void EraseAllPencil(GameObject[,] squares)
    {
        foreach (var item in squares)
        {
            TextMeshProUGUI[] penciltexts = item.GetComponent<PencilTexts>().penciltexts;
            foreach (var penciltext in penciltexts)
            {
                penciltext.enabled = false;
            }
        }
    }

    public string GetDifferenceGame(GameObject[] squares, int[,] game)
    {
        // squares = game + fill
        // game = game

        var filledgame = new System.Text.StringBuilder();
        foreach (var item in squares)
        {
            if (item.gameObject.GetComponent<GridSquare>().number_text.text == " ")
                filledgame.Append("0");
            else
                filledgame.Append(item.gameObject.GetComponent<GridSquare>().number_text.text);
        }

        string nofillgame = CreateString(game);

        // Compare both strings and do magic *-*

        var stuff = new System.Text.StringBuilder();
        for (int i = 0; i < filledgame.Length; i++)
        {
            if (nofillgame[i] == filledgame[i])
            {
                stuff.Append("0");
            }
            else
            {
                stuff.Append(filledgame[i]);
            }
        }

        return stuff.ToString();
    }


}

