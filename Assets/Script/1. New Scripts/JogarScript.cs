using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JogarScript : MonoBehaviour
{
    public int dificuldade = 1;
    [SerializeField] SudokuCreation sudokuCreation;

    [Header("Textos de dificuldade")]
    [SerializeField] TextMeshProUGUI textoMenuPrincipal;

    private void Start()
    {
        TextoDificuldade();
    }

    public void BotaoJogar()
    {
        sudokuCreation.CreateSudoku(dificuldade);

        // cria o sudoku
        // Coloca dentro dos quadrados.

    }

    public void DificuldadeDireita()
    {
        if (dificuldade < 5)
        {
            dificuldade++;
        }
        TextoDificuldade();
    }

    public void DificuldadeEsquerda()
    {
        if (dificuldade > 0)
        {
            dificuldade--;
        }
        TextoDificuldade();
    }

    public void TextoDificuldade()
    {
        if(dificuldade == 0)
        {
            textoMenuPrincipal.text = "Novato";
        }

        if (dificuldade == 1)
        {
            textoMenuPrincipal.text = "F�cil";
        }

        if (dificuldade == 2)
        {
            textoMenuPrincipal.text = "M�dio";
        }

        if (dificuldade == 3)
        {
            textoMenuPrincipal.text = "Dif�cil";
        }

        if (dificuldade == 4)
        {
            textoMenuPrincipal.text = "Especialista";
        }

        if (dificuldade == 5)
        {
            textoMenuPrincipal.text = "Terror";
        }
    }
}
