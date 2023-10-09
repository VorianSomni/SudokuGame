using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] MusicSFX musicSFX;
    public AudioSource Music;
    public AudioSource SFX;

    Coroutine MusicRoutine;

    public void PlayFirstMusic()
    {
        Music.clip = musicSFX.LoadMusicWhenRequested(0);
        Music.Play();
        MusicRoutine = StartCoroutine(LoadNextMusic());
    }

    public void PlayMusic()
    {
        Music.clip = musicSFX.LoadMusicWhenRequested(Random.Range(1, 5));
        Music.Play();
        MusicRoutine = StartCoroutine(LoadNextMusic());
    }

    IEnumerator LoadNextMusic()
    {
        while (Music.isPlaying)
        {   
            yield return new WaitForSeconds(3);
        }
        PlayMusic();
    }

    public void StopMusic()
    {
        if (MusicRoutine != null)
        {
            StopCoroutine(MusicRoutine);
        }
        
        Music.Stop();
        
    }

    public void PlayButtonSFX()
    {
        if (!SFX.mute)
        {
            SFX.PlayOneShot(musicSFX.SFXClip, 0.5f);
        }
        
    }
}
