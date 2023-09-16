using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class CelulaScript : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] GradeCelulasScript gCS;
    [SerializeField] TextMeshProUGUI bigNumber;
    [SerializeField] GameObject[] smallNumbers;


    public void OnPointerDown(PointerEventData eventData)
    {
        gCS.celulaScript = this;

        // Setar todos os quadrados para branco e as fontes para Normal
        gCS.ResetSquares(gCS.AxA_squares);

        // Pegar o endereço desse quadrado
        string pos = gCS.FindArrayPos(name);
        int j = Convert.ToInt16(Char.GetNumericValue(pos[0]));
        int i = Convert.ToInt16(Char.GetNumericValue(pos[1]));

        // Iluminar a linha, a coluna e o grid9x9
        if (gameObject.GetComponent<Button>().interactable != false)
        {
            gCS.Highlight(i, j);
        }
        /*
        gradeCelulasScript.selectedSquare = number_text;
        foreach (var numberButton in numberButtons)
        {
            numberButton.gridSquare = this;
        }
        */
    }

    public void SetNumbers(int number)
    {
        if(gCS.isPencilActivated)
        {
            if(smallNumbers[number - 1].activeInHierarchy)
            {
                smallNumbers[number - 1].SetActive(false);
                return;
            }
                
            smallNumbers[number - 1].SetActive(false);
            return;
        }
        bigNumber.text = number.ToString();
        ErasePencilNumbers();
        // EraseAllPencilInRowColumnGrid
    }

    void ErasePencilNumbers()
    {
        foreach (GameObject go in smallNumbers) { go.SetActive(false); }
    }
}
