using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    private AudioSource audioSource;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        }
        else {
            Debug.Log("More than one audio manager in the scene");
        }
    }

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip audio) {
        audioSource.PlayOneShot(audio);
    }
}
