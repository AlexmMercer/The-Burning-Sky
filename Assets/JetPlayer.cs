using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JetPlayer : MonoBehaviour
{
    [SerializeField] GameObject RestartPanel;
    [SerializeField] TextMeshProUGUI TimeValText;
    [SerializeField] TextMeshProUGUI TimerText;
    [SerializeField] TextMeshProUGUI MoneyValText;
    [SerializeField] TextMeshProUGUI CurrentMoneyValText;
    [SerializeField] TextMeshProUGUI MissilesDestroyedNumber;
    [SerializeField] GameManager gameManager;
    [SerializeField] Timer GameTimer;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<UnguidedMissile>(out var unguidedMissile))
        {
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
            Destroy(gameObject);
            TimeValText.text = $"Time: {TimerText.text}";
            gameManager.increaseTotalCoinsValue(gameManager.coinsCollectedPerRound);
            MoneyValText.text = $"Money: {gameManager.coinsCollectedPerRound} $ (Total: {gameManager.getTotalCoinsValue()})";
            gameManager.coinsCollectedPerRound = 0;
            RestartPanel.SetActive(true);
            GameTimer.HandlePlayerDeath();
        } else if(other.TryGetComponent<Coin>(out var coin))
        {
            gameManager.coinsCollectedPerRound++;
            CurrentMoneyValText.text = $"{gameManager.coinsCollectedPerRound} $";
        }
    }
}
