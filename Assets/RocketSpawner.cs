using UnityEngine;

public class RocketSpawner : MonoBehaviour
{
    public float spawnInterval = 50f;
    public float spawnRadius = 10f;
    public Transform playerTransform;
    public RocketPool rocketPool;

    private float timer = 0f;

    private void Start()
    {
        //rocketPool = GetComponent<RocketPool>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnRocket();
            timer = 0f;
        }
    }

    private void SpawnRocket()
    {
        rocketPool.playerTransform = playerTransform;
        rocketPool.spawnRadius = spawnRadius;
        rocketPool.SpawnRocket();
    }
}
