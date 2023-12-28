using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float PlayerForwardSpeed = 15.0f;
    [SerializeField] float PlayerRotationSpeed = 50.0f;
    [SerializeField] float PlayerSpeedCoefficient = 0.5f;

    private float horizontalInput;

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * PlayerForwardSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, PlayerRotationSpeed * horizontalInput * Time.deltaTime);
        PlayerForwardSpeed += PlayerSpeedCoefficient * Time.deltaTime;
    }

}