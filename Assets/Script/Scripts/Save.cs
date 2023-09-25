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
    }

    public void SalvarJogo()
    {
        GameSave gameSave = new GameSave(gV.LinguagemJogo, gV.oJogoFoiComprado, gV.VezesQueOJogoFoiAberto, gV.musicaAtiva, gV.efeitosSonorosAtivos, gV.tempoAtivo, gV.dificuldadeJogoVelho, gV.tempoJogoVelho, gV.VelhoSudokuGameCompleto, gV.VelhoSudokuGameIncompleto, gV.VelhoSudokuGamePreenchido);
        string savePath = GameSaveDataPath;

        Debug.Log("Saving Data at " + savePath);
        string json = JsonUtility.ToJson(gameSave);
        print(json);
        using StreamWriter writer = new StreamWriter(savePath);
        writer.Write(json);
        writer.Close();
        print("Salvou");
    }
}
