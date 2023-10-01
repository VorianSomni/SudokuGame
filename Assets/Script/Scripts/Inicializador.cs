using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Inicializador : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] GameVariables gameVariables;
    [SerializeField] Textos_e_Traducao textos_E_Traducao;

    [Header("Variaveis")]
    string GameSaveDataPath;
    string StatisticSaveDataPath;

    void Start()
    {
        gameVariables = GetComponent<GameVariables>();
        GameSaveDataPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "GameInfosData.json";
        GetComponent<Save>().GameSaveDataPath = GameSaveDataPath;

        if (!File.Exists(GameSaveDataPath))
        {
            GetComponent<Save>().SalvarJogo();
        }
        GetComponent<Save>().CarregarJogo();

        StatisticSaveDataPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "StatisticInfosData.json";
        GetComponent<Estatisticas>().StatisticSaveDataPath = StatisticSaveDataPath;

        if (!File.Exists(StatisticSaveDataPath))
        {
            GetComponent<Estatisticas>().SalvarEstatisticas();
        }
        GetComponent<Estatisticas>().ResgatarValoresDoArquivo();

        textos_E_Traducao.InicializarTextos();
        gameVariables.VezesQueOJogoFoiAberto++;

        GetComponent<JogarScript>().VerificarSeExisteJogoVelho();
    }
}
