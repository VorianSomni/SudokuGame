using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVariables : MonoBehaviour
{
    [Header("Vari�veis Gerais")]
    public int LinguagemJogo;
    public bool oJogoFoiComprado = false;
    public int VezesQueOJogoFoiAberto = 0;

    [Header("Vari�veis de Configura��o")]
    public bool musicaAtiva = true;
    public bool efeitosSonorosAtivos = true;
    public bool tempoAtivo = true;

    [Header("Vari�veis de Jogo")]
    public int dificuldadeMenu;
    public int dificuldadeAtual;
    public string AtualSudokuGameCompleto;
    public string AtualSudokuGameIncompleto;
    public string AtualSudokuGamePreenchido;

    // Se o jogador quiser continuar depois, o jogo atual vira velho
    // Deve-se salvar o tempo do jogo velho.
    public int dificuldadeJogoVelho;
    public int tempoJogoVelho;
    public string VelhoSudokuGameCompleto;
    public string VelhoSudokuGameIncompleto;
    public string VelhoSudokuGamePreenchido;
}
