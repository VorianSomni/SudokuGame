using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSave
{
    public int linguagem;
    public bool oJogoFoiComprado;
    public int vezesJogoAberto;

    public bool musicaLigada;
    public bool SFXLigado;
    public bool TempoLigado;

    public int DificuldadeJogoVelho;
    public int tempoJogoVelho;
    public string JogoVelhoCompleto;
    public string JogoVelhoIncompleto;
    public string JogoVelhoPreenchido;

    public int[,] Estatística;

    public GameSave(int linguagem, bool oJogoFoiComprado, int vezesJogoAberto, bool musicaLigada, bool sFXLigado, bool tempoLigado, int dificuldadeJogoVelho, int tempoJogoVelho, string jogoVelhoCompleto, string jogoVelhoIncompleto, string jogoVelhoPreenchido, int[,] estatística)
    {
        this.linguagem = linguagem;
        this.oJogoFoiComprado = oJogoFoiComprado;
        this.vezesJogoAberto = vezesJogoAberto;
        this.musicaLigada = musicaLigada;
        SFXLigado = sFXLigado;
        TempoLigado = tempoLigado;
        DificuldadeJogoVelho = dificuldadeJogoVelho;
        this.tempoJogoVelho = tempoJogoVelho;
        JogoVelhoCompleto = jogoVelhoCompleto;
        JogoVelhoIncompleto = jogoVelhoIncompleto;
        JogoVelhoPreenchido = jogoVelhoPreenchido;
        Estatística = estatística;
    }
}
