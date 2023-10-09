using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config_Toggle : MonoBehaviour
{
    [SerializeField] GameVariables gameVariables;
    [SerializeField] AudioManager audioManager;

    public void TempoOnOff()
    {
        gameVariables.tempoAtivo = !gameVariables.tempoAtivo;
        
    }

    public void MusicaOnOff()
    {
        gameVariables.musicaAtiva = !gameVariables.musicaAtiva;
        if (gameVariables.musicaAtiva == true)
        {
            if(audioManager.Music.isPlaying == false)
            {
                audioManager.PlayMusic();
            }
        }
        else
        {
            audioManager.StopMusic();
        }
        
    }

    public void SFXOnOff()
    {
        gameVariables.efeitosSonorosAtivos = !gameVariables.efeitosSonorosAtivos;
        audioManager.SFX.mute = !gameVariables.efeitosSonorosAtivos;
    }

    
}

