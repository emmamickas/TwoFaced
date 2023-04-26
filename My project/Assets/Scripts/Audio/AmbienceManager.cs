using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceManager : MonoBehaviour
{
    public AudioSource audioSource;

    public static AmbienceManager ambienceManagerInstance;

    // Start is called before the first frame update
    void Start()
    {
        ambienceManagerInstance = this;
        this.audioSource = GetComponent<AudioSource>();
        audioSource.loop = false; // Sound effects don't loop
    }

    public static void PlayDoorOpen()
    {
        ambienceManagerInstance.audioSource.clip = SoundEffectManager.soundEffectManagerInstance.doorOpen;

        if (!ambienceManagerInstance.audioSource.isPlaying)
        {
            ambienceManagerInstance.audioSource.Play();
        }
    }

    public static void PlayElevatorMoving()
    {
        if (ambienceManagerInstance == null)
        {
            return;
        }

        if (ambienceManagerInstance.audioSource == null)
        {
            ambienceManagerInstance.audioSource = ambienceManagerInstance.GetComponent<AudioSource>();
        }

        ambienceManagerInstance.audioSource.clip = SoundEffectManager.soundEffectManagerInstance.elevatorMoving;

        if (!ambienceManagerInstance.audioSource.isPlaying)
        {
            ambienceManagerInstance.audioSource.Play();
        }
    }

    public static void PlayTvTurnOn()
    {
        ambienceManagerInstance.audioSource.clip = SoundEffectManager.soundEffectManagerInstance.tvTurnOn;

        if (!ambienceManagerInstance.audioSource.isPlaying)
        {
            ambienceManagerInstance.audioSource.Play();
        }
    }

    public static void PlayTextBoxSound()
    {
        ambienceManagerInstance.audioSource.clip = SoundEffectManager.soundEffectManagerInstance.textBoxSound;

        ambienceManagerInstance.audioSource.Play();
    }
}
