using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public SoundManager GameSoundManager;
    private float CoinLifeTime = 15.0f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<JetPlayer>(out var player))
        {
            GameSoundManager.PlayCoinCollection();
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (CoinLifeTime > 0)
        {
            CoinLifeTime -= Time.deltaTime;
        }
        else
        {
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
}
