using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Inicializador : MonoBehaviour
{
    [Header("Telas")]
    [SerializeField] CanvasGroup[] TelasJogo;

    [Header("Scripts")]
    [SerializeField] GameVariables gameVariables;
    [SerializeField] Textos_e_Traducao textos_E_Traducao;
    [SerializeField] AudioManager audioManager;

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
        GetComponent<Backgrounds>().StartBackgrounds();

        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            // Internet is off
            gameVariables.hasInternet = false;
        }
        else
        {
            gameVariables.hasInternet = true;
            GetComponent<AdsInitializer>().InitializeAds();
        }

        if (gameVariables.musicaAtiva)
        {
            audioManager.PlayFirstMusic();
        }

        PadronizarTelas();
    }

    void PadronizarTelas()
    {
        for (int i = 0; i < TelasJogo.Length; i++)
        {
            LeanTween.alphaCanvas(TelasJogo[i], 0, 0.01f);
            TelasJogo[i].gameObject.SetActive(false);
        }

        TelasJogo[0].gameObject.SetActive(true);
        LeanTween.alphaCanvas(TelasJogo[0], 1, 1f);
    }
}
