using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioClip musicStart;
    void Start()
    {
        backgroundMusic.PlayOneShot(musicStart);
        backgroundMusic.PlayScheduled(AudioSettings.dspTime + musicStart.length);
    }
}
