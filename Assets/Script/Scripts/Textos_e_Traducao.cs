using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;

public class Textos_e_Traducao : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] GameVariables gameVariables;

    [Header("Files")]
    public TextAsset englishfile;
    public TextAsset portuguesefile;

    [Header("Others")]
    [SerializeField] TextMeshProUGUI textoDificuldadeMenuPrincipal;
    [SerializeField] TextMeshProUGUI textoDificuldadeJogo;
    [SerializeField] TextMeshProUGUI[] TextosDoJogo;
    [SerializeField] TextMeshProUGUI VersionText;
    [SerializeField] Image[] Buttons_to_Change;
    [SerializeField] Sprite[] ENG_Buttons_Sprites;
    [SerializeField] Sprite[] PT_Buttons_Sprites;

    public void InicializarTextos()
    {
        VersionText.text = "Ver. " + Application.version.ToString();
        if (gameVariables.VezesQueOJogoFoiAberto == 0)
        {
            LinguagemPrimeiroAcesso();
        }
        else
        {
            CarregarLinguagem(gameVariables.LinguagemJogo);
        }

    }

    #region Funções de Texto de Linguagem
    void LinguagemPrimeiroAcesso()
    {
        if (Application.systemLanguage == SystemLanguage.Portuguese)
            gameVariables.LinguagemJogo = 1;
        else
            gameVariables.LinguagemJogo = 0;

        CarregarLinguagem(gameVariables.LinguagemJogo);
    }

    public void CarregarLinguagem(int lang)
    {
        string[] lines;
        if (lang == 0)
        {
            lines = englishfile.text.Split('\n');
            textoDificuldadeMenuPrincipal.text = Texto_menu_ENDificuldade();
        }
        else
        {
            lines = portuguesefile.text.Split('\n');
            textoDificuldadeMenuPrincipal.text = Texto_menu_PTDificuldade();
        }

        gameVariables.LinguagemJogo = lang;
        TrocarLinguagem(lines);
    }

    public void TrocarLinguagem(string[] lines)
    {
        for (int i = 0; i < TextosDoJogo.Length; i++)
        {
            TextosDoJogo[i].text = lines[i];
        }
    }
    #endregion

    #region Textos de Dificuldade
    public void DificuldadeDireita()
    {
        if (gameVariables.dificuldadeMenu < 5)
        {
            gameVariables.dificuldadeMenu++;
        }

        if (gameVariables.LinguagemJogo == 0)
            textoDificuldadeMenuPrincipal.text = Texto_menu_ENDificuldade();
        else
            textoDificuldadeMenuPrincipal.text = Texto_menu_PTDificuldade();
    }

    public void DificuldadeEsquerda()
    {
        if (gameVariables.dificuldadeMenu > 0)
        {
            gameVariables.dificuldadeMenu--;
        }

        if (gameVariables.LinguagemJogo == 0)
            textoDificuldadeMenuPrincipal.text = Texto_menu_ENDificuldade();
        else
            textoDificuldadeMenuPrincipal.text = Texto_menu_PTDificuldade();
    }

    public string Texto_menu_PTDificuldade()
    {
        if (gameVariables.dificuldadeMenu == 0)
        {
            return "Novato";
        }

        if (gameVariables.dificuldadeMenu == 1)
        {
            return "Fácil";
        }

        if (gameVariables.dificuldadeMenu == 2)
        {
            return "Médio";
        }

        if (gameVariables.dificuldadeMenu == 3)
        {
            return "Difícil";
        }

        if (gameVariables.dificuldadeMenu == 4)
        {
            return "Especialista";
        }

        if (gameVariables.dificuldadeMenu == 5)
        {
            return "Terror";
        }

        return null;
    }

    public string Texto_menu_ENDificuldade()
    {
        if (gameVariables.dificuldadeMenu == 0)
        {
            return "Novice";
        }

        if (gameVariables.dificuldadeMenu == 1)
        {
            return "Easy";
        }

        if (gameVariables.dificuldadeMenu == 2)
        {
            return "Normal";
        }

        if (gameVariables.dificuldadeMenu == 3)
        {
            return "Hard";
        }

        if (gameVariables.dificuldadeMenu == 4)
        {
            return "Expert";
        }

        if (gameVariables.dificuldadeMenu == 5)
        {
            return "Horror";
        }
        return null;
    }

    public string Texto_jogo_PTDificuldade()
    {
        if (gameVariables.dificuldadeAtual == 0)
        {
            return "Novato";
        }

        if (gameVariables.dificuldadeAtual == 1)
        {
            return "Fácil";
        }

        if (gameVariables.dificuldadeAtual == 2)
        {
            return "Médio";
        }

        if (gameVariables.dificuldadeAtual == 3)
        {
            return "Difícil";
        }

        if (gameVariables.dificuldadeAtual == 4)
        {
            return "Especialista";
        }

        if (gameVariables.dificuldadeAtual == 5)
        {
            return "Terror";
        }

        return null;
    }

    public string Texto_jogo_ENDificuldade()
    {
        if (gameVariables.dificuldadeAtual == 0)
        {
            return "Novice";
        }

        if (gameVariables.dificuldadeAtual == 1)
        {
            return "Easy";
        }

        if (gameVariables.dificuldadeAtual == 2)
        {
            return "Normal";
        }

        if (gameVariables.dificuldadeAtual == 3)
        {
            return "Hard";
        }

        if (gameVariables.dificuldadeAtual == 4)
        {
            return "Expert";
        }

        if (gameVariables.dificuldadeAtual == 5)
        {
            return "Horror";
        }
        return null;
    }

    public void TextoDificuldadeDentroDoJogo()
    {
        if (gameVariables.LinguagemJogo == 0)
            textoDificuldadeJogo.text = Texto_jogo_ENDificuldade();
        else
            textoDificuldadeJogo.text = Texto_jogo_PTDificuldade();
    }
    #endregion
}
