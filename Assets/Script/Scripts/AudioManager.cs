using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] MusicSFX musicSFX;
    [SerializeField] AudioSource Music;
    [SerializeField] AudioSource SFX;

    Coroutine MusicRoutine;

    private void Start()
    {
        Music.clip = musicSFX.LoadMusicWhenRequested(4);
        Music.Play();
        MusicRoutine = StartCoroutine(LoadNextMusic());
    }

    public void PlayMusic()
    {
        Music.clip = musicSFX.LoadMusicWhenRequested(Random.Range(0, 3));
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
        StopCoroutine(MusicRoutine);
    }
}
