using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnguidedMissile : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    private float missileFuelTime = 20.0f;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<UnguidedMissile>(out var unguidedMissile))
        {
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
            Destroy(gameObject);
        }
    }


}
