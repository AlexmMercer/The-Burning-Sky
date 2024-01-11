using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateJet : MonoBehaviour
{
    private float tiltValue = 30.0f;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(Vector3.forward, -tiltValue);
        } else if (Input.GetKeyUp(KeyCode.A))
        {
            transform.Rotate(Vector3.forward, tiltValue);
        }

        if(Input.GetKeyDown(KeyCode.D)) 
        {
            transform.Rotate(Vector3.forward, tiltValue);
        } else if (Input.GetKeyUp(KeyCode.D))
        {
            transform.Rotate(Vector3.forward, -tiltValue);
        }
    }
}
