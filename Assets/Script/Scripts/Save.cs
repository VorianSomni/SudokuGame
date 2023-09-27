using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Save : MonoBehaviour
{
    public GameVariables gV;
    private string GameSaveDataPath = "";

    private void Start()
    {
        gV = GetComponent<GameVariables>();
        GameSaveDataPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "GameInfosData.json";

        if (!File.Exists(GameSaveDataPath))
        {
            SalvarJogo();
        }
        CarregarJogo();
    }

    public void SalvarJogo()
    {
        GameSave gameSave = new GameSave(gV.LinguagemJogo, gV.oJogoFoiComprado, gV.VezesQueOJogoFoiAberto, gV.musicaAtiva, gV.efeitosSonorosAtivos, gV.tempoAtivo, gV.dificuldadeJogoVelho, gV.tempoJogoVelho, gV.VelhoSudokuGameCompleto, gV.VelhoSudokuGameIncompleto, gV.VelhoSudokuGamePreenchido);
        string savePath = GameSaveDataPath;
        print(savePath);

        string json = JsonUtility.ToJson(gameSave);
        using StreamWriter writer = new StreamWriter(savePath);
        writer.Write(json);
        writer.Close();
        print("Jogo Salvo");
    }

    public void CarregarJogo()
    {
        if (File.Exists(GameSaveDataPath))
        {
            string statisticsPath = GameSaveDataPath;
            using StreamReader reader = new StreamReader(statisticsPath);
            string ItensDoSave = reader.ReadToEnd();

            GameSave GameRecuperado = JsonUtility.FromJson<GameSave>(ItensDoSave);
            GameRecuperado.vezesJogoAberto += 1;

            ColocarSaveDentroDasVariaveis(GameRecuperado);
            print("Variaveis carregadas");
        }
        
        GetComponent<JogarScript>().VerificarSeExisteJogoVelho();
       
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
        gV.VelhoSudokuGameCompleto = GameRecuperado.JogoVelhoCompleto;
        gV.VelhoSudokuGameIncompleto = GameRecuperado.JogoVelhoIncompleto;
        gV.VelhoSudokuGamePreenchido = GameRecuperado.JogoVelhoPreenchido;
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus == false)
        {
            SalvarJogo();
        }
    }

    private void OnApplicationQuit()
    {
        SalvarJogo();
    }
}
