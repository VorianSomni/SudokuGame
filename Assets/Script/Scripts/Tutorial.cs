using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameVariables gameVariables;

    [SerializeField] Sprite[] imagens;
    [SerializeField] string[] textosEN;
    [SerializeField] string[] textosPT;

    [SerializeField] Image tutorialImagem;
    [SerializeField] TextMeshProUGUI tutorialTexto;

    public byte count = 0;

    public void IniciarTutorial()
    {
        count = 0;
    }

    public void ColocarTutorialDentroDaImagemETexto()
    {
        tutorialImagem.sprite = imagens[count];

        if(gameVariables.LinguagemJogo == 0)
        {
            tutorialTexto.text = textosEN[count];
        }
        else
        {
            tutorialTexto.text = textosPT[count];
        }
        
    }

    public void BotãoDireita()
    {
        if(count < imagens.Length-1)
            count++;

        ColocarTutorialDentroDaImagemETexto();
    }

    public void BotãoEsquerda()
    {
        if (count > 0)
            count--;

        ColocarTutorialDentroDaImagemETexto();
    }
}
