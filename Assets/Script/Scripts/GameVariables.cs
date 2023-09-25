using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVariables : MonoBehaviour
{
    [Header("Variáveis Gerais")]
    public int LinguagemJogo;
    public bool oJogoFoiComprado = false;
    public int VezesQueOJogoFoiAberto = 0;

    [Header("Variáveis de Configuração")]
    public bool musicaAtiva = true;
    public bool efeitosSonorosAtivos = true;
    public bool tempoAtivo = true;

    [Header("Variáveis de Jogo")]
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

    [Header("Estatísticas")]
    public int[,] Estatisticas = new int[6, 5];
    // Essas estatísticas acima possuem 6 níveis de dificuldade e 5 campos de estatística. No caso, vamos chamar de [i,j]
    // A dificuldade do jogo vai dizer qual i será, enquanto terei de programar os j, que serão os mesmos para cada um.
    // Quero fazer dois scripts para lidar com o Save e com as Estatísticas. Todas as informações do Save saem desse script aqui.
    
}
