using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    [SerializeField] CoinFactory coinFactory;
    [SerializeField] int numberOfCoins = 10;
    [SerializeField] float spawnRadius = 10f;
    [SerializeField] float spawnInterval = 5f;

    [SerializeField] Transform playerTransform;

    void Start()
    {
        GenerateCoins();
        InvokeRepeating("GenerateCoins", spawnInterval, spawnInterval);
    }

    void GenerateCoins()
    {
        Vector3 playerPosition = playerTransform.position;
        for (int i = 0; i < numberOfCoins; i++)
        {
            float randomAngle = Random.Range(0f, 2f * Mathf.PI);
            float spawnX = playerPosition.x + spawnRadius * Mathf.Cos(randomAngle);
            float spawnZ = playerPosition.z + spawnRadius * Mathf.Sin(randomAngle);
            Vector3 spawnPosition = new Vector3(spawnX, playerPosition.y, spawnZ);

            coinFactory.SpawnCoin(spawnPosition);
        }
    }
}
