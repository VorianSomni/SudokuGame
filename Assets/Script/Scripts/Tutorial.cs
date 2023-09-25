using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial : MonoBehaviour
{
    [SerializeField] Sprite[] imagens;
    [SerializeField] string[] textos;

    [SerializeField] Image tutorialImagem;
    [SerializeField] TextMeshProUGUI tutorialTexto;

    public byte count = 0;

    public void ColocarTutorialDentroDaImagemETexto()
    {
        tutorialImagem.sprite = imagens[count];
        tutorialTexto.text = textos[count];
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
