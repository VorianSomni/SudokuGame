using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CellsScript : MonoBehaviour
{
    public TextMeshProUGUI NumeroPrincipal;
    public GameObject[] NumerosLapis;
    public JogoScript jogoScript;
    public bool podeEditar = true;

    Color Selected = new Color(128f / 255f, 212 / 255f, 245 / 255f, 255 / 255f);
    

    public void LigarDesligarNumeroLapis(int num)
    {

        if (NumerosLapis[num-1].GetComponent<CanvasGroup>().alpha == 1)
        {
            NumerosLapis[num - 1].GetComponent<CanvasGroup>().alpha = 0;
            return;
        }
        NumerosLapis[num - 1].GetComponent<CanvasGroup>().alpha = 1;
    }

    public void DesligarNumeroLapis(int num)
    {
        NumerosLapis[num - 1].GetComponent<CanvasGroup>().alpha = 0;
    }

    public void DesligarTodosOsNumeros()
    {
        foreach (GameObject num in NumerosLapis)
        {
            num.GetComponent<CanvasGroup>().alpha = 0;
        }
    }

    public void SelecionarQuadrado()
    {
        jogoScript.QuadradoSelecionado = gameObject;
        jogoScript.NumeroPrincipal = NumeroPrincipal;
        jogoScript.IluminarQuadrados();
        
    }
    
}
