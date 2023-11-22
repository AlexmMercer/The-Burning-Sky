using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnguidedMissileController : MonoBehaviour
{
    [SerializeField] float MissileMovingSpeed = 50.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * MissileMovingSpeed * Time.deltaTime);
        MissileMovingSpeed += 2.0f * Time.deltaTime;
    }
}
