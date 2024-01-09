using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float LifeTime = 3;
    [SerializeField] SoundManager SoundManager;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<GuidedMissile>(out var missile))
        {
            //Destroy(other.gameObject);
            Destroy(gameObject);
            //SoundManager.PlayExplosion();
        }
    }
    void Update()
    {
        if(LifeTime > 0)
        {
            LifeTime -= Time.deltaTime;
        } else
        {
            Destroy(gameObject);
        }
    }
}
