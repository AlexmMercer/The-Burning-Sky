using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedMissile : MonoBehaviour
{
    [SerializeField] SoundManager GameSoundManager;
    [SerializeField] ParticleSystem ExplosionEffect;
    [SerializeField] float missileFuelTime = 10.0f;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<GuidedMissile>(out var unguidedMissile))
        {
           Instantiate(ExplosionEffect, transform.position,
            Quaternion.identity);
           ExplosionEffect.Play();
           GameSoundManager.PlayExplosion();
           Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (missileFuelTime > 0)
        {
            missileFuelTime -= Time.deltaTime;
        } else
        {
            GameSoundManager.PlayExplosion();
            Destroy(gameObject);
        }
    }


}
