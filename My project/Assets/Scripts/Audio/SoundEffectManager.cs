using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    public AudioClip playerShoot;
    public AudioClip gruntShoot;
    public AudioClip goonShoot;
    public AudioClip bruteShoot;
    public AudioClip bossShoot;
    public AudioClip gruntSpawn;
    public AudioClip goonSpawn;
    public AudioClip bruteSpawn;
    public AudioClip bossSpawn;
    public AudioClip doorOpen;
    public AudioClip elevatorMoving;
    public AudioClip tvTurnOn;
    public AudioClip textBoxSound;
    public AudioSource audioSource;

    public static SoundEffectManager soundEffectManagerInstance;

    // Start is called before the first frame update
    void Start()
    {
        this.audioSource = GetComponent<AudioSource>();
        audioSource.loop = false; // Sound effects don't loop
        soundEffectManagerInstance = this;
    }

    public static void PlayEnemyShoot(AudioClip enemyShootSound)
    {
        soundEffectManagerInstance.audioSource.clip = enemyShootSound;
        
        soundEffectManagerInstance.audioSource.Play();
    }

    public static void PlayEnemySpawn(AudioClip enemySpawnSound)
    {
        Debug.Log("Spawn Sound");

        soundEffectManagerInstance.audioSource.clip = enemySpawnSound;

        soundEffectManagerInstance.audioSource.Play();
    }

    public static void PlayGruntShoot()
    {
        soundEffectManagerInstance.audioSource.clip = soundEffectManagerInstance.gruntShoot;

        if (!soundEffectManagerInstance.audioSource.isPlaying)
        {
            soundEffectManagerInstance.audioSource.Play();
        }
    }

    public static void PlayGoonShoot()
    {
        soundEffectManagerInstance.audioSource.clip = soundEffectManagerInstance.goonShoot;

        if (!soundEffectManagerInstance.audioSource.isPlaying)
        {
            soundEffectManagerInstance.audioSource.Play();
        }
    }

    public static void PlayBruteShoot()
    {
        soundEffectManagerInstance.audioSource.clip = soundEffectManagerInstance.bruteShoot;

        if (!soundEffectManagerInstance.audioSource.isPlaying)
        {
            soundEffectManagerInstance.audioSource.Play();
        }
    }

    public static void PlayBossShoot()
    {
        soundEffectManagerInstance.audioSource.clip = soundEffectManagerInstance.bossShoot;

        if (!soundEffectManagerInstance.audioSource.isPlaying)
        {
            soundEffectManagerInstance.audioSource.Play();
        }
    }

    public static void PlayGruntSpawn()
    {
        soundEffectManagerInstance.audioSource.clip = soundEffectManagerInstance.gruntSpawn;

        if (!soundEffectManagerInstance.audioSource.isPlaying)
        {
            soundEffectManagerInstance.audioSource.Play();
        }
    }

    public static void PlayGoonSpawn()
    {
        soundEffectManagerInstance.audioSource.clip = soundEffectManagerInstance.goonSpawn;

        if (!soundEffectManagerInstance.audioSource.isPlaying)
        {
            soundEffectManagerInstance.audioSource.Play();
        }
    }

    public static void PlayBruteSpawn()
    {
        soundEffectManagerInstance.audioSource.clip = soundEffectManagerInstance.bruteSpawn;

        if (!soundEffectManagerInstance.audioSource.isPlaying)
        {
            soundEffectManagerInstance.audioSource.Play();
        }
    }

    public static void PlayBossSpawn()
    {
        soundEffectManagerInstance.audioSource.clip = soundEffectManagerInstance.bossSpawn;

        if (!soundEffectManagerInstance.audioSource.isPlaying)
        {
            soundEffectManagerInstance.audioSource.Play();
        }
    }
}
