using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnguidedMissileController : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    public float rotationSpeed = 200f;

    [SerializeField] float speedCoefficient = 7.0f;

    void Update()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;

            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            speed += speedCoefficient * Time.deltaTime;
        }
    }
}
