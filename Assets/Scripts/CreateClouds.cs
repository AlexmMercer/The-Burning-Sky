using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateClouds : MonoBehaviour
{
    /*
     * 1. Облака должны генерироваться под игроком перед началом игрового процесса.
     * 2. Диапазон генерирующихся облак - в квадрате  
     */

    [SerializeField] GameObject Cloud;
    [SerializeField] GameObject Player;
    [SerializeField] int CloudsNumber;

    private float xCoord;
    private float yCoord;
    private float zCoord;

    private void Start()
    {
        yCoord = Player.transform.position.y - 10;

        for(int i = 0; i < CloudsNumber; i++)
        {
            xCoord = Random.Range(-700, 700);
            zCoord = Random.Range(-700, 700);
            Vector3 newCloudPosition = new Vector3(xCoord, yCoord, zCoord);
            Instantiate(Cloud, newCloudPosition, Cloud.transform.rotation);
        }
    }
}
