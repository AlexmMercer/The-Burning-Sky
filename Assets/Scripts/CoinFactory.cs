using UnityEngine;

public class CoinFactory : MonoBehaviour
{
    [SerializeField] GameObject coinPrefab;

    public GameObject SpawnCoin(Vector3 position)
    {
        return Instantiate(coinPrefab, position, Quaternion.identity);
    }
}
