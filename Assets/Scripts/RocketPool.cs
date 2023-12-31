using UnityEngine;
using System.Collections.Generic;

public class RocketPool : MonoBehaviour
{
    public GameObject rocketPrefab;
    public int poolSize = 10;
    public float spawnRadius1 = 5f;
    public float spawnRadius2 = 10f;
    public Transform playerTransform;

    private List<GameObject> rocketPool = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject rocket = Instantiate(rocketPrefab);
            rocket.SetActive(false);
            rocketPool.Add(rocket);
        }
    }

    public GameObject GetRocketFromPool()
    {
        foreach (GameObject rocket in rocketPool)
        {
            if(rocket != null)
            {
                if (!rocket.activeInHierarchy)
                {
                    return rocket;
                }
            }
        }


        GameObject newRocket = Instantiate(rocketPrefab);
        newRocket.SetActive(false);
        rocketPool.Add(newRocket);
        return newRocket;
    }

    public void SpawnRocket()
    {
        float randomRadius = Random.Range(spawnRadius1, spawnRadius2);

        float randomAngle = Random.Range(0f, 2f * Mathf.PI);

        float spawnX = playerTransform.position.x + randomRadius * Mathf.Cos(randomAngle);
        float spawnZ = playerTransform.position.z + randomRadius * Mathf.Sin(randomAngle);
        Vector3 spawnPosition = new Vector3(spawnX, playerTransform.position.y, spawnZ);

        GameObject rocket = GetRocketFromPool();

        if (rocket != null)
        {
            rocket.transform.position = spawnPosition;
            rocket.GetComponent<UnguidedMissileController>().target = playerTransform;
            rocket.SetActive(true);
        }
    }
}
