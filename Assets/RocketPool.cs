using UnityEngine;
using System.Collections.Generic;

public class RocketPool : MonoBehaviour
{
    public GameObject rocketPrefab;
    public int poolSize = 10;
    public float spawnRadius = 5f;
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
            if (!rocket.activeInHierarchy)
            {
                return rocket;
            }
        }

        GameObject newRocket = Instantiate(rocketPrefab);
        newRocket.SetActive(false);
        rocketPool.Add(newRocket);
        return newRocket;
    }

    public void SpawnRocket()
    {
        Vector2 randomOffset = Random.insideUnitCircle.normalized * spawnRadius;
        Vector3 spawnPosition = playerTransform.position + new Vector3(randomOffset.x, 0f, randomOffset.y);

        GameObject rocket = GetRocketFromPool();
        rocket.transform.position = spawnPosition;
        rocket.GetComponent<UnguidedMissileController>().target = playerTransform;
        rocket.SetActive(true);
    }
}
