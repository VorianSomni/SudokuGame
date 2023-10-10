using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JogarScript : MonoBehaviour
{
    [SerializeField] Estatisticas estatisticas;
    [SerializeField] GameVariables gameVariables;
    [SerializeField] GameObject BtnContinuar;


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
        gameVariables.GetComponent<Textos_e_Traducao>().TextoDificuldadeDentroDoJogo(gameVariables.LinguagemJogo);
        gameVariables.estaJogando = true;
        gameVariables.GetComponent<JogoScript>().ColocarJogoDentroDosQuadrados();
        gameVariables.GetComponent<JogoScript>().ColocarJogoPreenchidoDentroDosQuadrados();
    }

    public void BotaoPopUpSim()
    {
        gameVariables.GetComponent<JogoScript>().DeletarJogoVelho();
        gameVariables.GetComponent<SudokuCreation>().CreateSudoku(gameVariables.dificuldadeMenu);
        gameVariables.GetComponent<TransicaoTelas>().AbrirJogo();
        gameVariables.GetComponent<JogoScript>().ColocarJogoDentroDosQuadrados();
        gameVariables.GetComponent<Popups>().SetPopUpPanelOff();
        gameVariables.estaJogando = true;
        gameVariables.dificuldadeAtual = gameVariables.dificuldadeMenu;
        estatisticas.AdiconarValores(gameVariables.dificuldadeAtual, pjogoIniciado: 1);

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

        gameVariables.GetComponent<Textos_e_Traducao>().TextoDificuldadeDentroDoJogo(gameVariables.LinguagemJogo);
    }

    public void BotaoVoltarAoMenuPrincipal()
    {
        gameVariables.GetComponent<Popups>().PopupVoltarAoMenuPrincipal();
        gameVariables.GetComponent<JogoScript>().PararTempo();
    }

    public void BotaoAbandonarJogo()
    {
        estatisticas.AdiconarValores(gameVariables.dificuldadeAtual, pjogoAbandonado: 1);
        gameVariables.estaJogando = false;
        gameVariables.GetComponent<JogoScript>().BotaoLapisImagem.color = Color.white;
        gameVariables.GetComponent<JogoScript>().lapisAtivo = false;
        gameVariables.GetComponent<JogoScript>().QuadradoSelecionado = null;
        gameVariables.GetComponent<JogoScript>().ResetarTodosOsQuadrados();
        gameVariables.GetComponent<JogoScript>().PararTempo();
        gameVariables.GetComponent<JogoScript>().DeletarJogoAtual();
        gameVariables.GetComponent<JogoScript>().ZerarTimer();
        gameVariables.GetComponent<TransicaoTelas>().VoltarAoMenu();
        VerificarSeExisteJogoVelho();
    }

    public void ComecarJogoNovoTendoJogoVelho()
    {
        estatisticas.AdiconarValores(gameVariables.dificuldadeJogoVelho, pjogoAbandonado: 1);
        BotaoPopUpSim();
    }

    public void BotaoContinuarDepois()
    {
        gameVariables.GetComponent<JogoScript>().BotaoLapisImagem.color = Color.white;
        gameVariables.GetComponent<JogoScript>().lapisAtivo = false;
        gameVariables.GetComponent<JogoScript>().QuadradoSelecionado = null;
        gameVariables.GetComponent<JogoScript>().ResetarTodosOsQuadrados();
        gameVariables.GetComponent<JogoScript>().PararTempo();
        gameVariables.GetComponent<JogoScript>().SalvarJogoVelho();
        gameVariables.GetComponent<JogoScript>().ZerarTimer();
        gameVariables.GetComponent<TransicaoTelas>().VoltarAoMenu();
        gameVariables.estaJogando = false;
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

    public void ResetAd()
    {
        if (gameVariables.oJogoFoiComprado == false)
        {
            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                // Internet is off
                gameVariables.hasInternet = false;

            }
            else
            {
                // Internet is on
                gameVariables.hasInternet = true;
            }

            if (gameVariables.hasInternet)
            {
                GetComponent<RewardedAdsButton>().ShowRewardedAd(0);
            }
            else
            {
                ResetarJogoEmAndamento();
            }
            
        }
        else
        {
            ResetarJogoEmAndamento();
        }
    }

    public void ResetarJogoEmAndamento()
    {
        gameVariables.GetComponent<JogoScript>().ResetarTodosOsQuadrados();
        gameVariables.GetComponent<JogoScript>().ColocarJogoDentroDosQuadrados();

        gameVariables.GetComponent<JogoScript>().BotaoLapisImagem.color = Color.white;
        gameVariables.GetComponent<JogoScript>().lapisAtivo = false;
        gameVariables.GetComponent<JogoScript>().PararTempo();
        gameVariables.GetComponent<JogoScript>().ZerarTimer();


        if (gameVariables.tempoAtivo == true)
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

    private void OnApplicationFocus(bool focus)
    {
        
        if(focus == false)
        {
            print("Salvando informações...");
            // Se estiver na tela de jogo...
            if (gameVariables.estaJogando)
            {
                GetComponent<JogoScript>().SalvarJogoVelho();
                GetComponent<Save>().SalvarJogo();
                GetComponent<Estatisticas>().SalvarEstatisticas();
            }

            // Se não estiver na tela de jogo...
            if (gameVariables.estaJogando == false)
            {
                GetComponent<Save>().SalvarJogo();
                GetComponent<Estatisticas>().SalvarEstatisticas();
            }
            print("Informações salvas");
        }
        else
        {
            if (gameVariables.estaJogando)
            {
                GetComponent<JogoScript>().ContinuarJogoVelho();
            }
            
        }
        
    }
    
}
