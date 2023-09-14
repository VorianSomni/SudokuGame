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

    public void BotaoJogar()
    {
        sudokuCreation.CreateSudoku(dificuldade);
    }


    public void DificuldadeDireita()
    {
        if (dificuldade < 5)
        {
            dificuldade++;
        }
    }

    public void DificuldadeEsquerda()
    {
        if (dificuldade > 0)
        {
            dificuldade--;
        }
    }

    public void TextoDificuldade()
    {
        if(dificuldade == 0)
        {
            textoMenuPrincipal.text = "Novato";
        }

        if (dificuldade == 1)
        {
            textoMenuPrincipal.text = "Fácil";
        }

        if (dificuldade == 2)
        {
            textoMenuPrincipal.text = "Médio";
        }

        if (dificuldade == 3)
        {
            textoMenuPrincipal.text = "Difícil";
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
