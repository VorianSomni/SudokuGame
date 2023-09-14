using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVariables : MonoBehaviour
{
    [Header("Variáveis Gerais")]
    public int LinguagemJogo;
    public bool oJogoFoiComprado = false;

    [Header("Variáveis de Configuração")]
    public bool musicaAtiva = true;
    public bool efeitosSonorosAtivos = true;
    public bool tempoAtivo = true;

    [Header("Variáveis de Jogo")]
    public string AtualSudokuGameCompleto;
    public string AtualSudokuGameIncompleto;
    public string VelhoSudokuGameCompleto;
    public string VelhoSudokuGameIncompleto;
}
