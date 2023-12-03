using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPlayer : MonoBehaviour
{
    [SerializeField] GameObject RestartPanel;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<UnguidedMissile>(out var unguidedMissile))
        {
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
            Destroy(gameObject);
            RestartPanel.SetActive(true);
        }
    }
}
