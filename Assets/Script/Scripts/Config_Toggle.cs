using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Config_Toggle : MonoBehaviour
{
    [SerializeField] GameVariables gameVariables;

    public void TempoOnOff()
    {
        gameVariables.tempoAtivo = !gameVariables.tempoAtivo;
    }

    public void MusicaOnOff()
    {
        gameVariables.musicaAtiva = !gameVariables.musicaAtiva;
    }

    public void SFXOnOff()
    {
        gameVariables.efeitosSonorosAtivos = !gameVariables.efeitosSonorosAtivos;
    }
}
