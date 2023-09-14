using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CelulaScript : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] GradeCelulasScript gradeCelulasScript;



    public void OnPointerDown(PointerEventData eventData)
    {
        gradeCelulasScript.celulaScript = this;

        // Setar todos os quadrados para branco e as fontes para Normal
        gradeCelulasScript.ResetSquare(gradeCelulasScript.AxA_squares);

        // Pegar o endereço desse quadrado
        string pos = gradeCelulasScript.FindArrayPos(name);
        int j = Convert.ToInt16(Char.GetNumericValue(pos[0]));
        int i = Convert.ToInt16(Char.GetNumericValue(pos[1]));

        // Iluminar a linha, a coluna e o grid9x9
        if (gameObject.GetComponent<Button>().interactable != false)
        {
            gradeCelulasScript.Highlight(i, j);
        }
        /*
        gradeCelulasScript.selectedSquare = number_text;
        foreach (var numberButton in numberButtons)
        {
            numberButton.gridSquare = this;
        }
        */
    }
}
