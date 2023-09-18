using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JogarScript : MonoBehaviour
{
    [SerializeField] GameVariables gameVariables;
    [SerializeField] SudokuCreation sudokuCreation;

    public void BotaoJogar()
    {
        sudokuCreation.CreateSudoku(gameVariables.dificuldadeMenu);
        gameVariables.dificuldadeAtual = gameVariables.dificuldadeMenu;
    }
    
    public void BotaoContinuar()
    {
        gameVariables.dificuldadeAtual = gameVariables.dificuldadeJogoVelho;
    }
}
