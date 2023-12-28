using UnityEngine;

public class RocketSpawner : MonoBehaviour
{
    [SerializeField] float spawnInterval = 450000.0f;
    public Transform playerTransform;
    public RocketPool rocketPool;

    private float timer = 0f;

    private void Start()
    {
        SpawnRocket();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 2 * spawnInterval)
        {
            SpawnRocket();
            timer = 0f;
        }
    }

    private void SpawnRocket()
    {
        rocketPool.playerTransform = playerTransform;
        //rocketPool.spawnRadius = spawnRadius;
        rocketPool.SpawnRocket();
    }
}
