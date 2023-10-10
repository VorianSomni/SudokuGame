using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompraDoJogo : MonoBehaviour
{
    [SerializeField] Button botaoDeCompra;
    
    public void OJogoFoiComprado()
    {
        GetComponent<GameVariables>().oJogoFoiComprado = true;
        botaoDeCompra.interactable = false;
        GetComponent<BannerAdExample>().DestroyBannerView();
        GetComponent<Save>().SalvarJogo();

    }

    public void FalhaNaCompra()
    {
        
    }
}
