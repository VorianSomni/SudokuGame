using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVariables : MonoBehaviour
{
    [Header("Vari�veis Gerais")]
    public int LinguagemJogo;
    public bool oJogoFoiComprado = false;

    [Header("Vari�veis de Configura��o")]
    public bool musicaAtiva = true;
    public bool efeitosSonorosAtivos = true;
    public bool tempoAtivo = true;

    [Header("Vari�veis de Jogo")]
    public string AtualSudokuGameCompleto;
    public string AtualSudokuGameIncompleto;
    public string VelhoSudokuGameCompleto;
    public string VelhoSudokuGameIncompleto;
}
