using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransicaoTelas : MonoBehaviour
{
    [Header("Telas")]
    public CanvasGroup MenuPrincipal;
    public CanvasGroup Jogo;
    public CanvasGroup Configuracao;
    public CanvasGroup Estatisticas;
    public CanvasGroup Tutorial;
    public CanvasGroup SobreNos;
    public CanvasGroup NoAds;
    public GameObject TelaInvisivel;

    [Header("Pop-ups")]
    public GameObject AvisoNovoJogo;
    public GameObject ResetarJogo;
    public GameObject VoltarAoMenuPrincipal;
    public GameObject JogoIncorreto;
    public GameObject VoceVenceu;

    [Header("Variáveis")]
    public byte LastScreen;


    #region Screen to screen methods

    // Qualquer botão Voltar, exceto o da Configuração
    public void VoltarAoMenu()
    {
        FadeInPanel(MenuPrincipal);
        FadeOutPanel(Jogo);
        FadeOutPanel(Estatisticas);
        FadeOutPanel(Tutorial);
        FadeOutPanel(SobreNos);
        FadeOutPanel(NoAds);
        GetComponent<Popups>().SetPopUpPanelOff();
    }   


    // Botão Configuração do Menu Principal
    public void AbrirConfigDoMenu()
    {
        LastScreen = 0;
        FadeOutPanel(MenuPrincipal);
        FadeInPanel(Configuracao);
    }

    // Botão Configuração do Jogo
    public void AbrirConfigDoJogo()
    {
        LastScreen = 1;
        FadeOutPanel(Jogo);
        FadeInPanel(Configuracao);
    }

    // Botão Voltar da Configuração
    public void SairDeConfiguracao()
    {
        FadeOutPanel(Configuracao);

        if (LastScreen == 0)
        {
            FadeInPanel(MenuPrincipal);
        }
        if (LastScreen == 1)
        {
            FadeInPanel(Jogo);
        }

    }

    public void AbrirJogo()
    {
        FadeOutPanel(MenuPrincipal);
        FadeInPanel(Jogo);
    }

    public void AbrirEstatisticas()
    {
        FadeOutPanel(MenuPrincipal);
        FadeInPanel(Estatisticas);
    }

    public void AbrirTutorial()
    {
        FadeOutPanel(MenuPrincipal);
        FadeInPanel(Tutorial);
    }

    public void AbrirSobreNos()
    {
        FadeOutPanel(MenuPrincipal);
        FadeInPanel(SobreNos);
    }

    public void WinToMenu()
    {
        Unpop_VoceVenceu();
        VoltarAoMenu();
    }

    public void AbrirNoAds()
    {
        FadeOutPanel(MenuPrincipal);
        FadeInPanel(NoAds);
    }

    #endregion

    #region Pop-ups methods

    public void Pop_AvisoNovoJogo()
    {
        AvisoNovoJogo.SetActive(true);
    }

    public void Pop_ResetarJogo()
    {
        ResetarJogo.SetActive(true);
    }

    public void Pop_VoltarAoMenuPrincipal()
    {
        VoltarAoMenuPrincipal.SetActive(true);
    }

    public void Pop_JogoIncorreto()
    {
        JogoIncorreto.SetActive(true);
    }

    public void Pop_VoceVenceu()
    {
        VoceVenceu.SetActive(true);
        // tocar sfx de aplausos
    }

    public void Unpop_AvisoNovoJogo()
    {
        AvisoNovoJogo.SetActive(false);
    }

    public void Unpop_ResetarJogo()
    {
        ResetarJogo.SetActive(false);
    }

    public void Unpop_VoltarAoMenuPrincipal()
    {
        VoltarAoMenuPrincipal.SetActive(false);
    }

    public void Unpop_JogoIncorreto()
    {
        JogoIncorreto.SetActive(false);
    }

    public void Unpop_VoceVenceu()
    {
        VoceVenceu.SetActive(false);
    }

    #endregion

    #region Fade
    public void FadeInPanel(CanvasGroup panel)
    {
        StartCoroutine(Fade(true, panel));
    }

    public void FadeOutPanel(CanvasGroup panel)
    {
        StartCoroutine(Fade(false, panel));
    }

    IEnumerator Fade(bool in_out, CanvasGroup panel)
    {
        if (in_out == true)
        {
            TelaInvisivel.SetActive(true);
            panel.gameObject.SetActive(true);
            LeanTween.alphaCanvas(panel, 1, 0.5f);
            yield return new WaitForSeconds(0.6f);
            TelaInvisivel.SetActive(false);
        }
        else
        {
            TelaInvisivel.SetActive(true);
            LeanTween.alphaCanvas(panel, 0, 0.5f);
            yield return new WaitForSeconds(0.6f);
            panel.gameObject.SetActive(false);
            TelaInvisivel.SetActive(false);
        }
        yield return null;
    }
    #endregion
}
