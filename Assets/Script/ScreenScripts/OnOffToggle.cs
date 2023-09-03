using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnOffToggle : MonoBehaviour
{
    public CanvasGroup ON;
    public CanvasGroup CheckmarkON;
    public Image SliderON;
    public Image SliderOFF;
    public bool IsOn;
    public float time = 0.3f;
    public float pos = -26.7f;

    public void Toggle()
    {
        IsOn = !IsOn;

        if (IsOn)
        {
            LeanTween.moveLocalX(SliderON.gameObject, -pos, time).setEase(LeanTweenType.easeOutSine);
            LeanTween.moveLocalX(SliderOFF.gameObject, -pos, time).setEase(LeanTweenType.easeOutSine);
            LeanTween.alphaCanvas(ON, 1, time);
            LeanTween.alphaCanvas(CheckmarkON, 1, time);
        }
        else
        {
            LeanTween.moveLocalX(SliderON.gameObject, pos, time).setEase(LeanTweenType.easeOutSine);
            LeanTween.moveLocalX(SliderOFF.gameObject, pos, time).setEase(LeanTweenType.easeOutSine);
            LeanTween.alphaCanvas(ON, 0, time);
            LeanTween.alphaCanvas(CheckmarkON, 0, time);
        }
    }

}
