using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompraDoJogo : MonoBehaviour
{
    public void OJogoFoiComprado()
    {
        GetComponent<GameVariables>().oJogoFoiComprado = true;
        GetComponent<Save>().SalvarJogo();
    }

    public void FalhaNaCompra()
    {
        
    }
}
