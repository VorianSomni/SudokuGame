using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Backgrounds : MonoBehaviour
{
    [SerializeField] CanvasGroup[] backgrounds;
    [SerializeField] float tempo;
    int a = 0;
    int b;

    public void StartBackgrounds()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            LeanTween.alphaCanvas(backgrounds[i], 0, 0.01f);
        }
        LeanTween.alphaCanvas(backgrounds[a], 1, 0.01f);
        StartCoroutine(MudeBackgrounds());
    }

    IEnumerator MudeBackgrounds()
    {
        while(true)
        {
            b = Random.Range(0, backgrounds.Length);
            while (a == b)
            {
                b = Random.Range(0, backgrounds.Length);
            }

            LeanTween.alphaCanvas(backgrounds[a], 0, tempo);
            LeanTween.alphaCanvas(backgrounds[b], 1, tempo);

            yield return new WaitForSeconds(tempo);
            a = b;
        }
    }
}
