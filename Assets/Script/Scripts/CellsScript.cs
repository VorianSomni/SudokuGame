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

    public void LigarDesligarNumero(int num)
    {
        if (NumerosLapis[num].activeInHierarchy)
        {
            NumerosLapis[num].SetActive(false);
            return;
        }
        NumerosLapis[num].SetActive(true);
    }

    public void DesligarTodosOsNumeros()
    {
        foreach (GameObject num in NumerosLapis)
        {
            num.SetActive(false);
        }
    }

    public void SelecionarQuadrado()
    {
        jogoScript.QuadradoSelecionado = gameObject;
        jogoScript.NumeroPrincipal = NumeroPrincipal;
        jogoScript.IluminarQuadrados();
        
    }

    
}
