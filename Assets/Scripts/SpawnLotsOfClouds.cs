using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject.SpaceFighter;

public class SpawnLotsOfClouds : MonoBehaviour
{
    [SerializeField] GameObject Cloud;
    [SerializeField] GameObject Player;
    [SerializeField] int NumberOfCloudsToSpawn;
    private List<GameObject> clouds;
    private float cloudXCoord;
    private float cloudYCoord;
    private float cloudZCoord;

    void Start()
    {
        InvokeRepeating("SpawnClouds", 0.0f, 3.0f);
    }

    private void Update()
    {
        clouds = GameObject.FindGameObjectsWithTag("Cloud").ToList<GameObject>();
        for (int i = 0;i < clouds.Count;i++)
        {
            clouds[i].transform.Translate(0, 19 * Time.deltaTime, 0);
        }
    }

    void SpawnClouds()
    {
        cloudYCoord = Player.transform.position.y - 10;

        for (int i = 0; i < NumberOfCloudsToSpawn; i++)
        {
            cloudXCoord = Random.Range(500, 600);
            cloudZCoord = Random.Range(-55, 150);
            Vector3 newCloudPosition = new Vector3(cloudXCoord, cloudYCoord, cloudZCoord);
            Instantiate(Cloud, newCloudPosition, Cloud.transform.rotation);
        }
    }
}
