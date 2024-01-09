using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateClouds : MonoBehaviour
{
    [SerializeField] GameObject Cloud;
    [SerializeField] GameObject Player;
    [SerializeField] int CloudsNumber;

    private float cloudXCoord;
    private float cloudYCoord;
    private float cloudZCoord;

    private void Start()
    {
        cloudYCoord = Player.transform.position.y - 10;

        for(int i = 0; i < CloudsNumber; i++)
        {
            cloudXCoord = Random.Range(-700, 700);
            cloudZCoord = Random.Range(-700, 700);
            Vector3 newCloudPosition = new Vector3(cloudXCoord, cloudYCoord, cloudZCoord);
            Instantiate(Cloud, newCloudPosition, Cloud.transform.rotation);
        }
    }
}
