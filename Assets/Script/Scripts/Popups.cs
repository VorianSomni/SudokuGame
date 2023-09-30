using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using Newtonsoft.Json;

public class Popups : MonoBehaviour
{
    [SerializeField] GameObject PopupPanel;
    [SerializeField] GameObject NovoJogo;
    [SerializeField] GameObject ResetarJogo;
    [SerializeField] GameObject VoltarAoMenuPrincipal;
    [SerializeField] GameObject JogoIncorreto;
    [SerializeField] GameObject VoceVenceu;

    [Header("Venceu")]
    [SerializeField] TextMeshProUGUI dificuldadeTexto;
    [SerializeField] TextMeshProUGUI TempoTexto;
    [SerializeField] TextMeshProUGUI statusTexto;
    [SerializeField] public string[] status;

    public void SetPopUpPanelOn()
    {
        PopupPanel.SetActive(true);
    }

    public void SetPopUpPanelOff()
    {
        JogoIncorreto.SetActive(false);
        VoceVenceu.SetActive(false);
        VoltarAoMenuPrincipal.SetActive(false);
        ResetarJogo.SetActive(false);
        NovoJogo.SetActive(false);
        PopupPanel.SetActive(false);
    }

    public void PopupNovoJogo()
    {
        SetPopUpPanelOn();
        NovoJogo.SetActive(true);
    }

    public void PopupResetarJogo()
    {
        SetPopUpPanelOn();
        ResetarJogo.SetActive(true);
    }

    public void PopupVoltarAoMenuPrincipal()
    {
        SetPopUpPanelOn();
        VoltarAoMenuPrincipal.SetActive(true);
    }

    public void PopupVoceVenceu()
    {
        SetPopUpPanelOn();
        VoceVenceu.SetActive(true);
    }

    public void PopupJogoIncorreto()
    {
        SetPopUpPanelOn();
        JogoIncorreto.SetActive(true);
    }

    public void MexerNaTelaDeVitoria(int dificuldade, int ptempoJogo, int melhorTempoAntigo = 0, int piorTempoAntigo = 0)
    {
        TextoDificuldade(dificuldade);
        TempoTexto.text = TempoString(ptempoJogo);
        
        if (melhorTempoAntigo != 0 && ptempoJogo != 0)
        {
            if(ptempoJogo < melhorTempoAntigo)
            {
                statusTexto.text = "Você superou seu tempo anterior!";
                return;
            }
        }

        if(piorTempoAntigo != 0 && ptempoJogo != 0)
        {
            if(ptempoJogo > piorTempoAntigo)
            {
                statusTexto.text = "Seu tempo anterior foi melhor que o atual, não desista!";
                return;
            }
        }

        statusTexto.text = status[Random.Range(0, status.Length)];
    }

    public void TextoDificuldade(int dificuldade)
    {
        if (dificuldade == 0)
        {
            dificuldadeTexto.text = "Novato";
        }

        if (dificuldade == 1)
        {
            dificuldadeTexto.text = "Fácil";
        }

        if (dificuldade == 2)
        {
            dificuldadeTexto.text = "Médio";
        }

        if (dificuldade == 3)
        {
            dificuldadeTexto.text = "Difícil";
        }

        if (dificuldade == 4)
        {
            dificuldadeTexto.text = "Especialista";
        }

        if (dificuldade == 5)
        {
            dificuldadeTexto.text = "Terror";
        }
    }

    string TempoString(int tempo)
    {
        int minutes = Mathf.FloorToInt(tempo / 60);
        int seconds = Mathf.FloorToInt(tempo % 60);
        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
        return timerString;
    }
    
}
