using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inicializador : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] GameVariables gameVariables;
    [SerializeField] Textos_e_Traducao textos_E_Traducao;


    void Start()
    {
        // Pegar o save, colocar no GameVariables e rodar o resto.


        textos_E_Traducao.InicializarTextos();
        gameVariables.VezesQueOJogoFoiAberto++;
    }
}
