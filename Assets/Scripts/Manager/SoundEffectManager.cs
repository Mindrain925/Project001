using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    // Static instance of the SoundEffectManager
    public static SoundEffectManager Instance { get; private set; }
    private AudioSource audioSource;
    [SerializeField] private AudioClip attachedAudioClip;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // If there is already an instance and it's not this one, destroy this game object
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Assign the static instance and make it persist across scenes
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public void Play(AudioClip audioClip, float startTime = 0.0f){
        attachedAudioClip = audioClip;
        
        audioSource.clip = attachedAudioClip;
        audioSource.time = startTime;
        audioSource.Play();
    }
}
