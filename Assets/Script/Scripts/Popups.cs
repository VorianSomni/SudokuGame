using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popups : MonoBehaviour
{
    [SerializeField] GameObject PopupPanel;
    [SerializeField] GameObject NovoJogo;
    [SerializeField] GameObject ResetarJogo;
    [SerializeField] GameObject VoltarAoMenuPrincipal;
    [SerializeField] GameObject JogoIncorreto;
    [SerializeField] GameObject VoceVenceu;


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
}
