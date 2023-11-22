using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float PlayerForwardSpeed = 15.0f;
    [SerializeField] float PlayerRotationSpeed = 50.0f;

    private float horizontalInput;
    private Animator animator;

    private void Start()
    {
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        Vector3 jetDirection = Vector3.Cross(Vector3.right, Vector3.forward);
        transform.Translate(Vector3.forward * PlayerForwardSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, PlayerRotationSpeed * horizontalInput * Time.deltaTime);
    }
}