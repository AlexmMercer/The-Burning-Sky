using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCoin : MonoBehaviour
{
    [SerializeField] float CoinRotationSpeed = 100.0f;

    private void Update()
    {
        transform.Rotate(Vector3.up, CoinRotationSpeed * Time.deltaTime);
    }
}
