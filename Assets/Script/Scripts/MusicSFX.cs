using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MusicSFX : MonoBehaviour
{
    public AudioClip SFXClip;
    [SerializeField] AudioClip[] MusicClips = new AudioClip[5];

    public AudioClip LoadMusicWhenRequested(int num)
    {
        if (MusicClips[num] != null)
        {
            return MusicClips[num];
        }

        string path = "";

        if (num == 0)
            path = "Musics/Prelude No. 19 - Chris Zabriskie";
        if (num == 1)
            path = "Musics/catch-my-breath-ambient-boy-main-version-10-00-13494";
        if (num == 2)
            path = "Musics/delicate-texture-ambient-boy-main-version-09-53-13503";
        if (num == 3)
            path = "Musics/linear-circle-ambient-boy-main-version-09-54-13512";
        if (num == 4)
            path = "Musics/mindfulness-journey-ambient-boy-main-version-09-58-13506";

        MusicClips[num] = Resources.Load(path) as AudioClip;

        return MusicClips[num];
    }

    public AudioClip LoadSFXWhenRequested()
    {
        return SFXClip;
    }
}
