using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //[SerializeField] GameManager PlayerGameManager;
    private float CoinLifeTime = 15.0f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<JetPlayer>(out var player))
        {
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
}
