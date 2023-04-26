using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundEffectManager : MonoBehaviour
{
    public AudioSource audioSource;

    public static PlayerSoundEffectManager playerSoundEffectManagerInstance;

    // Start is called before the first frame update
    void Start()
    {
        this.audioSource = GetComponent<AudioSource>();
        audioSource.loop = false; // Sound effects don't loop
        playerSoundEffectManagerInstance = this;
    }

    public static void PlayPlayerShoot()
    {
        playerSoundEffectManagerInstance.audioSource.clip = SoundEffectManager.soundEffectManagerInstance.playerShoot;

        if (!playerSoundEffectManagerInstance.audioSource.isPlaying)
        {
            playerSoundEffectManagerInstance.audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
