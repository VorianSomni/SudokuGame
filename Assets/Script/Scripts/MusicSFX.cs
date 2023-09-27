using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MusicSFX : MonoBehaviour
{
    [SerializeField] AudioClip[] MusicClips;
    [SerializeField] AudioClip SFXClip;

    public AudioClip LoadMusicWhenRequested(int num)
    {

        return MusicClips[num];
        
    }

    public AudioClip LoadSFXWhenRequested()
    {
        return SFXClip;
    }
}
