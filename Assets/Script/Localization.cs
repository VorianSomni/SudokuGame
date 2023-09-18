using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Localization : MonoBehaviour
{
    public TextMeshProUGUI[] Labels;
    string[] lines;
    public SudokuGame sudokuGame;
    public JsonSaving jsonSaving;
    public AdsManager adsManager;
    TextAsset englishfile;
    TextAsset portuguesefile;

    [SerializeField] Image[] Buttons_to_Change;
    [SerializeField] Sprite[] ENG_Buttons_Sprites;
    [SerializeField] Sprite[] PT_Buttons_Sprites;

    void Start()
    {
        englishfile = Resources.Load<TextAsset>("english/lang");
        portuguesefile = Resources.Load<TextAsset>("portuguese/lang");

        jsonSaving.ConfigLoad();

        if(jsonSaving.configSave != null)
        {
            sudokuGame.lang = jsonSaving.configSave.language;
        }
        else
        {
            if (Application.systemLanguage == SystemLanguage.English)
            {
                sudokuGame.lang = 1;
            }

            if (Application.systemLanguage == SystemLanguage.Portuguese)
            {
                sudokuGame.lang = 2;
            }

        }
        //sudokuGame.lang = jsonSaving.configSave.language;

        sudokuGame.SetConfig();

        CarregarLinguagem(sudokuGame.lang);
        TrocarLinguagem();
    }

    public void CarregarLinguagem(int lang)
    {
        if(lang == 1)
        {
            lines = englishfile.text.Split('\n');
        }
        else
        {
            lines = portuguesefile.text.Split('\n');
        }
        lines[7] = lines[7].Replace("<br>", "\n");
        lines[16] = lines[16].Replace("<br>", "\n");

        TrocarLinguagem();
        sudokuGame.lang = lang;
        sudokuGame.SetDifText(sudokuGame._difficulty, lang);
        ChangeButtonsToLang(lang);
        sudokuGame.SaveConfig();
    }


    public void TrocarLinguagem()
    {
        for (int i = 0; i < Labels.Length; i++)
        {
            Labels[i].text = lines[i];
        }
    }

    public void ChangeButtonsToLang(int lang)
    {

        if (lang == 1)
        {
            for (int i = 0; i < Buttons_to_Change.Length; i++)
            {
                Buttons_to_Change[i].GetComponent<Image>().sprite = ENG_Buttons_Sprites[i];
            }
        }
        else
        {
            for (int i = 0; i < Buttons_to_Change.Length; i++)
            {
                Buttons_to_Change[i].GetComponent<Image>().sprite = PT_Buttons_Sprites[i];
            }
        }
    }

}
