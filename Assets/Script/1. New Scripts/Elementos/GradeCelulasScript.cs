using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GradeCelulasScript : MonoBehaviour
{
    


    [Header("Game Related")]
    public GameObject[,] AxA_squares = new GameObject[9, 9];
    public TextMeshProUGUI selectedSquare;
    public TextMeshProUGUI DificultyText;
    public GameObject wrongSolution;
    public GameObject ContinueBtn;
    public GameObject[] squares;
    public CelulaScript celulaScript;

    Color Sgray = new Color(50f / 255f, 50 / 255f, 50 / 255f, 255 / 255f);
    int i = 0;
    int j = 0;

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

    public void ResetSquares(GameObject[,] grid)
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

    public string FindArrayPos(string name)
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (AxA_squares[i, j].name == name)
                {
                    string pos = $"{i}{j}";
                    return pos;
                }
            }
        }
        return null;
    }

    #region Highlight

    public void Highlight(int row, int col)
    {
        HighlightRow(col);
        HighlightColumn(row);
        Highlight9x9Grid(col, row);
        HighlightNumbers();
        HighlightCell();
    }

    public void ExternalHighlight()
    {
        HighlightNumbers();
        HighlightCell();
    }

    public void EraseHighlight()
    {
        ResetSquare(AxA_squares);
        Highlight(i, j);
        UnHighlightNumbers();
    }

    private void HighlightCell()
    {
        if (CanChangeNubers)
            gameObject.GetComponent<Image>().color = Selected;
    }

    private void HighlightRow(int row)
    {

        for (int col = 0; col < 9; col++)
        {
            rowsquares[col] = sudokugame.AxA_squares[row, col];
        }

        foreach (var item in rowsquares)
        {
            item.gameObject.GetComponent<Image>().color = ClearBlue;
        }
    }

    private void HighlightColumn(int col)
    {

        for (int row = 0; row < 9; row++)
        {
            columnquares[row] = sudokugame.AxA_squares[row, col];
        }

        foreach (var item in columnquares)
        {
            item.gameObject.GetComponent<Image>().color = ClearBlue;
        }

    }

    private void Highlight9x9Grid(int row, int col)
    {

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                grid9x9squares[i, j] = sudokugame.AxA_squares[3 * (row / 3) + i, 3 * (col / 3) + j];
            }
        }

        foreach (var item in grid9x9squares)
        {
            item.gameObject.GetComponent<Image>().color = ClearBlue;
        }

    }

    private void HighlightNumbers()
    {
        int count = 0;
        GameObject[] equalNumberSquares = new GameObject[81];
        if (number_text.text != " " & number_text.text != "0")
        {
            foreach (var square in sudokugame.AxA_squares)
            {
                if (square.GetComponent<GridSquare>().number_text.text == number_text.text)
                {
                    equalNumberSquares[count] = square;
                    count++;
                }
            }
        }

        foreach (var item in equalNumberSquares)
        {
            if (item != null)
            {
                item.gameObject.GetComponent<Image>().color = SlightlyDarkerBlue;
                item.GetComponent<GridSquare>().number_text.fontStyle = FontStyles.Bold;
            }

        }

    }

    private void UnHighlightNumbers()
    {
        foreach (var number in sudokugame.AxA_squares)
        {
            number.GetComponent<GridSquare>().number_text.fontStyle = FontStyles.Normal;
        }
    }
    #endregion
}
