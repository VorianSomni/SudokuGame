using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JogarScript : MonoBehaviour
{
    [SerializeField] Estatisticas estatisticas;
    [SerializeField] GameVariables gameVariables;
    [SerializeField] GameObject BtnContinuar;

    private void Start()
    {
        VerificarSeExisteJogoVelho();
    }


    public void BotaoJogar()
    {
        if(gameVariables.VelhoSudokuGameCompleto != "")
        {
            gameVariables.GetComponent<Popups>().PopupNovoJogo();
            return;
        }

        BotaoPopUpSim();
    }
    
    public void BotaoContinuar()
    {
        gameVariables.dificuldadeAtual = gameVariables.dificuldadeJogoVelho;
        gameVariables.GetComponent<JogoScript>().ContinuarJogoVelho();
        gameVariables.GetComponent<TransicaoTelas>().AbrirJogo();
        gameVariables.GetComponent<Textos_e_Traducao>().TextoDificuldadeDentroDoJogo();
        gameVariables.GetComponent<JogoScript>().ColocarJogoDentroDosQuadrados();
        gameVariables.GetComponent<JogoScript>().ColocarJogoPreenchidoDentroDosQuadrados();
    }

    public void BotaoPopUpSim()
    {
        gameVariables.GetComponent<JogoScript>().DeletarJogoVelho();
        gameVariables.GetComponent<SudokuCreation>().CreateSudoku(gameVariables.dificuldadeMenu);
        gameVariables.GetComponent<TransicaoTelas>().AbrirJogo();
        gameVariables.GetComponent<Textos_e_Traducao>().TextoDificuldadeDentroDoJogo();
        gameVariables.GetComponent<JogoScript>().ColocarJogoDentroDosQuadrados();
        gameVariables.GetComponent<Popups>().SetPopUpPanelOff();
        gameVariables.dificuldadeAtual = gameVariables.dificuldadeMenu;
        estatisticas.AdiconarValores(gameVariables.dificuldadeMenu, pjogoIniciado: 1);

        if(gameVariables.tempoAtivo == true)
        {
            gameVariables.GetComponent<JogoScript>().TempoAtivoNesseJogo = true;
            gameVariables.jogoAtualComTempoAtivado = true;
        }
        else
        {
            gameVariables.GetComponent<JogoScript>().TempoAtivoNesseJogo = false;
            gameVariables.jogoAtualComTempoAtivado = false;
        }
    }

    public void BotaoVoltarAoMenuPrincipal()
    {
        gameVariables.GetComponent<Popups>().PopupVoltarAoMenuPrincipal();
        gameVariables.GetComponent<JogoScript>().PararTempo();
    }

    public void BotaoAbandonarJogo()
    {
        gameVariables.GetComponent<JogoScript>().ResetarTodosOsQuadrados();
        gameVariables.GetComponent<JogoScript>().PararTempo();
        gameVariables.GetComponent<JogoScript>().DeletarJogoAtual();
        gameVariables.GetComponent<JogoScript>().ZerarTimer();
        gameVariables.GetComponent<TransicaoTelas>().VoltarAoMenu();
        gameVariables.GetComponent<Popups>().SetPopUpPanelOff();
        estatisticas.AdiconarValores(gameVariables.dificuldadeMenu, pjogoAbandonado: 1);
        VerificarSeExisteJogoVelho();
    }

    public void ComecarJogoNovoTendoJogoVelho()
    {
        estatisticas.AdiconarValores(gameVariables.dificuldadeMenu, pjogoAbandonado: 1);
        BotaoPopUpSim();
    }

    public void BotaoContinuarDepois()
    {
        gameVariables.GetComponent<JogoScript>().ResetarTodosOsQuadrados();
        gameVariables.GetComponent<JogoScript>().PararTempo();
        gameVariables.GetComponent<JogoScript>().SalvarJogoVelho();
        gameVariables.GetComponent<JogoScript>().ZerarTimer();
        gameVariables.GetComponent<TransicaoTelas>().VoltarAoMenu();
        gameVariables.GetComponent<Popups>().SetPopUpPanelOff();
        VerificarSeExisteJogoVelho();
    }

    public void BotaoRetornarAoJogo()
    {
        gameVariables.GetComponent<Popups>().SetPopUpPanelOff();
        gameVariables.GetComponent<JogoScript>().ComecarTempo();
    }

    public void VerificarSeExisteJogoVelho()
    {
        if(gameVariables.VelhoSudokuGameCompleto != "")
        {
            BtnContinuar.SetActive(true);
            return;
        }
        BtnContinuar.SetActive(false);
    }
}
