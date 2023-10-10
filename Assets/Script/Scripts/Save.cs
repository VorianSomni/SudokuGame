using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Save : MonoBehaviour
{
    public GameVariables gV;
    public string GameSaveDataPath = "";

    [SerializeField] OnOffToggle botaoTempo;
    [SerializeField] OnOffToggle botaoSFX;
    [SerializeField] OnOffToggle botaoMusica;


    public void SalvarJogo()
    {
        GameSave gameSave = new GameSave(gV.LinguagemJogo, gV.oJogoFoiComprado, gV.VezesQueOJogoFoiAberto, gV.musicaAtiva, gV.efeitosSonorosAtivos, gV.tempoAtivo, gV.dificuldadeJogoVelho, gV.tempoJogoVelho, gV.jogoVelhoComTempoAtivado, gV.VelhoSudokuGameCompleto, gV.VelhoSudokuGameIncompleto, gV.VelhoSudokuGamePreenchido);
        string savePath = GameSaveDataPath;
        print(savePath);

        string json = JsonUtility.ToJson(gameSave);
        using StreamWriter writer = new StreamWriter(savePath);
        writer.Write(json);
        writer.Close();
        print("Jogo Salvo");
        print(json);
    }

    public void CarregarJogo()
    {
        if (File.Exists(GameSaveDataPath))
        {
            string statisticsPath = GameSaveDataPath;
            using StreamReader reader = new StreamReader(statisticsPath);
            string ItensDoSave = reader.ReadToEnd();

            GameSave GameRecuperado = JsonUtility.FromJson<GameSave>(ItensDoSave);
            print("Carregando jogo " + GameRecuperado.vezesJogoAberto);

            ColocarSaveDentroDasVariaveis(GameRecuperado);
            print("Variaveis carregadas");
        }
        
        GetComponent<JogarScript>().VerificarSeExisteJogoVelho();
        ResolverToggles();

    }

    public void ResolverToggles()
    {
        if (!gV.tempoAtivo)
        {
            botaoTempo.Toggle();
        }

        if (!gV.efeitosSonorosAtivos)
        {
            botaoSFX.Toggle();
        }

        if (!gV.musicaAtiva)
        {
            botaoMusica.Toggle();
        }
    }

    public void ColocarSaveDentroDasVariaveis(GameSave GameRecuperado)
    {
        gV.LinguagemJogo = GameRecuperado.linguagem;
        gV.oJogoFoiComprado = GameRecuperado.oJogoFoiComprado;
        gV.VezesQueOJogoFoiAberto = GameRecuperado.vezesJogoAberto;

        gV.musicaAtiva = GameRecuperado.musicaLigada;
        gV.efeitosSonorosAtivos = GameRecuperado.SFXLigado;
        gV.tempoAtivo = GameRecuperado.TempoLigado;

        gV.dificuldadeJogoVelho = GameRecuperado.DificuldadeJogoVelho;
        gV.tempoJogoVelho = GameRecuperado.tempoJogoVelho;
        gV.jogoVelhoComTempoAtivado = GameRecuperado.jogoVelhoComTempoAtivado;
        gV.VelhoSudokuGameCompleto = GameRecuperado.JogoVelhoCompleto;
        gV.VelhoSudokuGameIncompleto = GameRecuperado.JogoVelhoIncompleto;
        gV.VelhoSudokuGamePreenchido = GameRecuperado.JogoVelhoPreenchido;
    }

    

    
}
