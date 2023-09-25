using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Estatisticas : MonoBehaviour
{
    [SerializeField] int[] jogoIniciado = new int[6];
    int[] jogoFinalizado = new int[6];
    int[] jogoAbandonado = new int[6];
    int[] melhorTempo = new int[6];
    int[] piorTempo = new int[6];
    // Novato é 0, Terror é 5

    string StatisticSaveDataPath;

    private void Start()
    {
        StatisticSaveDataPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "StatisticInfosData.json";

        if (!File.Exists(StatisticSaveDataPath))
        {
            SalvarEstatisticas();
        }
        ResgatarValoresDoArquivo();
    }


    public void SalvarEstatisticas()
    {
        GameEstatisticas gameEstatisticas = new GameEstatisticas(
            jogoIniciado[0], jogoFinalizado[0], jogoAbandonado[0], melhorTempo[0], piorTempo[0],
            jogoIniciado[1], jogoFinalizado[1], jogoAbandonado[1], melhorTempo[1], piorTempo[1],
            jogoIniciado[2], jogoFinalizado[2], jogoAbandonado[2], melhorTempo[2], piorTempo[2],
            jogoIniciado[3], jogoFinalizado[3], jogoAbandonado[3], melhorTempo[3], piorTempo[3],
            jogoIniciado[4], jogoFinalizado[4], jogoAbandonado[4], melhorTempo[4], piorTempo[4],
            jogoIniciado[5], jogoFinalizado[5], jogoAbandonado[5], melhorTempo[5], piorTempo[5] );

        string statisticsPath = StatisticSaveDataPath;
        Debug.Log("Saving Data at " + statisticsPath);
        string json = JsonUtility.ToJson(gameEstatisticas);
        print(json);
        using StreamWriter writer = new StreamWriter(statisticsPath);
        writer.Write(json);
        writer.Close();
        print("Salvou");

    }

    public void AdiconarValores(int dificuldade, int pjogoIniciado = 0, int pjogoFinalizado = 0, int pjogoAbandonado = 0, int ptempo = 0)
    {
        jogoIniciado[dificuldade] += pjogoIniciado;
        jogoFinalizado[dificuldade] += pjogoFinalizado;
        jogoAbandonado[dificuldade] += pjogoAbandonado;

        if(ptempo != 0)
        {
            if (ptempo > piorTempo[dificuldade]) piorTempo[dificuldade] = ptempo;
            if (ptempo < melhorTempo[dificuldade]) melhorTempo[dificuldade] = ptempo;
        }
    }

    public void ResgatarValoresDoArquivo()
    {
        if (File.Exists(StatisticSaveDataPath))
        {
            string statisticsPath = StatisticSaveDataPath;
            using StreamReader reader = new StreamReader(statisticsPath);
            string ItensDoSave = reader.ReadToEnd();

            GameEstatisticas estatisticasRecuperadas = JsonUtility.FromJson<GameEstatisticas>(ItensDoSave);

            ColocarSaveDentroDosArrays(estatisticasRecuperadas);
        }
    }

    private void ColocarSaveDentroDosArrays(GameEstatisticas estatisticasRecuperadas)
    {
        jogoIniciado[0] = estatisticasRecuperadas.jogoIniciado_n;
        jogoFinalizado[0] = estatisticasRecuperadas.jogoFinalizado_n;
        jogoAbandonado[0] = estatisticasRecuperadas.jogoAbandonado_n;
        melhorTempo[0] = estatisticasRecuperadas.melhorTempo_n;
        piorTempo[0] = estatisticasRecuperadas.piorTempo_n;

        jogoIniciado[1] = estatisticasRecuperadas.jogoIniciado_f;
        jogoFinalizado[1] = estatisticasRecuperadas.jogoFinalizado_f;
        jogoAbandonado[1] = estatisticasRecuperadas.jogoAbandonado_f;
        melhorTempo[1] = estatisticasRecuperadas.melhorTempo_f;
        piorTempo[1] = estatisticasRecuperadas.piorTempo_f;

        jogoIniciado[2] = estatisticasRecuperadas.jogoIniciado_m;
        jogoFinalizado[2] = estatisticasRecuperadas.jogoFinalizado_m;
        jogoAbandonado[2] = estatisticasRecuperadas.jogoAbandonado_m;
        melhorTempo[2] = estatisticasRecuperadas.melhorTempo_m;
        piorTempo[2] = estatisticasRecuperadas.piorTempo_m;

        jogoIniciado[3] = estatisticasRecuperadas.jogoIniciado_d;
        jogoFinalizado[3] = estatisticasRecuperadas.jogoFinalizado_d;
        jogoAbandonado[3] = estatisticasRecuperadas.jogoAbandonado_d;
        melhorTempo[3] = estatisticasRecuperadas.melhorTempo_d;
        piorTempo[3] = estatisticasRecuperadas.piorTempo_d;

        jogoIniciado[4] = estatisticasRecuperadas.jogoIniciado_e;
        jogoFinalizado[4] = estatisticasRecuperadas.jogoFinalizado_e;
        jogoAbandonado[4] = estatisticasRecuperadas.jogoAbandonado_e;
        melhorTempo[4] = estatisticasRecuperadas.melhorTempo_e;
        piorTempo[4] = estatisticasRecuperadas.piorTempo_e;

        jogoIniciado[5] = estatisticasRecuperadas.jogoIniciado_t;
        jogoFinalizado[5] = estatisticasRecuperadas.jogoFinalizado_t;
        jogoAbandonado[5] = estatisticasRecuperadas.jogoAbandonado_t;
        melhorTempo[5] = estatisticasRecuperadas.melhorTempo_t;
        piorTempo[5] = estatisticasRecuperadas.piorTempo_t;
    }
}
