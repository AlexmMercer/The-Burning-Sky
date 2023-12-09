using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSea : MonoBehaviour
{
    [SerializeField] float LifeTime = 20;
    [SerializeField] float Speed = 5.0f;

    private void Update()
    {
        LifeTime -= Time.deltaTime;
        if (LifeTime <= 0) Destroy(gameObject);
        else transform.Translate(0, 0, (-Speed) * Time.deltaTime);
    }
}
