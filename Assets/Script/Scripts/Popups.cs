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
    [SerializeField] public string[] statusPT;
    [SerializeField] public string[] statusEN;

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
        TextoDificuldadeDentroDoJogo(GetComponent<GameVariables>().LinguagemJogo, dificuldade);
        TempoTexto.text = TempoString(ptempoJogo);
        
        
        if(GetComponent<GameVariables>().LinguagemJogo == 0)
        {
            if (melhorTempoAntigo != 0 && ptempoJogo != 0)
            {
                if (ptempoJogo < melhorTempoAntigo)
                {
                    statusTexto.text = statusEN[0];
                    return;
                }
            }

            if (piorTempoAntigo != 0 && ptempoJogo != 0)
            {
                if (ptempoJogo > piorTempoAntigo)
                {
                    statusTexto.text = statusEN[1];
                    return;
                }
            }

            statusTexto.text = statusEN[Random.Range(2, statusEN.Length)];
        }
        else
        {
            if (melhorTempoAntigo != 0 && ptempoJogo != 0)
            {
                if (ptempoJogo < melhorTempoAntigo)
                {
                    statusTexto.text = statusPT[0];
                    return;
                }
            }

            if (piorTempoAntigo != 0 && ptempoJogo != 0)
            {
                if (ptempoJogo > piorTempoAntigo)
                {
                    statusTexto.text = statusPT[1];
                    return;
                }
            }

            statusTexto.text = statusPT[Random.Range(2, statusPT.Length)];
        }
        
    }

    public string Texto_jogo_PTDificuldade(int dificuldade)
    {
        if (dificuldade == 0)
        {
            return "Novato";
        }

        if (dificuldade == 1)
        {
            return "Fácil";
        }

        if (dificuldade == 2)
        {
            return "Médio";
        }

        if (dificuldade == 3)
        {
            return "Difícil";
        }

        if (dificuldade == 4)
        {
            return "Especialista";
        }

        if (dificuldade == 5)
        {
            return "Terror";
        }

        return null;
    }

    public string Texto_jogo_ENDificuldade(int dificuldade)
    {
        if (dificuldade == 0)
        {
            return "Novice";
        }

        if (dificuldade == 1)
        {
            return "Easy";
        }

        if (dificuldade == 2)
        {
            return "Normal";
        }

        if (dificuldade == 3)
        {
            return "Hard";
        }

        if (dificuldade == 4)
        {
            return "Expert";
        }

        if (dificuldade == 5)
        {
            return "Horror";
        }
        return null;
    }

    public void TextoDificuldadeDentroDoJogo(int lang, int dificuldade)
    {
        if (lang == 0)
        {
            dificuldadeTexto.text = Texto_jogo_ENDificuldade(dificuldade);
        }
        else
        {
            dificuldadeTexto.text = Texto_jogo_PTDificuldade(dificuldade);
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
