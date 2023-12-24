using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnguidedMissile : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] SoundManager GameSoundManager;
    [SerializeField] ParticleSystem ExplosionEffect;
    private float missileFuelTime = 10.0f;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<UnguidedMissile>(out var unguidedMissile))
        {
           Instantiate(ExplosionEffect, transform.position,
            Quaternion.identity);
           ExplosionEffect.Play();
           GameSoundManager.PlayExplosion();
           Destroy(gameObject);
        }
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        // ???? ????????? ?????????? ???????
        yield return new WaitForSeconds(delay);


        // ?????????? ??????
        Destroy(gameObject);
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
