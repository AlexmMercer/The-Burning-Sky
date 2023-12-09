using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSea : MonoBehaviour
{
    [SerializeField] float SendTimer = 0;
    [SerializeField] float Frequency = 5;
    [SerializeField] GameObject Floor;
    private float roadXGenerationPos = 557.2758f;
    private float roadYGenerationPos = 0.0f;
    private float roadZGenerationPos = -74.26117f;

    private void Update()
    {
        SendTimer -= Time.deltaTime;
        if (SendTimer <= 0)
        {
            Instantiate(Floor, new Vector3(roadXGenerationPos,
                                           roadYGenerationPos,
                                           roadZGenerationPos),
                                           transform.rotation);
            SendTimer = Frequency;
        }
    }

}
