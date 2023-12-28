using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip ExplosionSound;
    [SerializeField] AudioClip CoinSound;
    private static AudioSource gameSoundManager;

    void Start()
    {
        gameSoundManager = GetComponent<AudioSource>();
    }

    public void PlayExplosion()
    {
        gameSoundManager.clip = ExplosionSound;
        gameSoundManager.Play();
    }

    public void PlayCoinCollection()
    {
        gameSoundManager.clip = CoinSound;
        gameSoundManager.Play();
    }

}
