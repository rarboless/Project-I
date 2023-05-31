using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioClip musicStart;

    void Start() {
        StartCoroutine(FadeIn(backgroundMusic, 5));
        backgroundMusic.PlayOneShot(musicStart);
        backgroundMusic.PlayScheduled(AudioSettings.dspTime + musicStart.length);
    }
    
    public static IEnumerator FadeIn(AudioSource audioSource, float FadeTime) {
        audioSource.Play();
        audioSource.volume = 0f;
        while (audioSource.volume < 1) {
            audioSource.volume += Time.deltaTime / FadeTime;
            yield return null;
        }
    }
    
}
