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
    [SerializeField] GameObject RotateLeftButton;
    [SerializeField] GameObject RotateRightButton;
    [SerializeField] GameObject MachineGunButton;
    [SerializeField] GameObject MissileButton;
    [SerializeField] GameObject PauseButton;
    [SerializeField] ParticleSystem ExplosionEffect;
    [SerializeField] SoundManager GameSoundManager;
    [SerializeField] AudioClip explosionClip;
    [SerializeField] Timer GameTimer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<GuidedMissile>(out var guidedMissile))
        {
            Instantiate(ExplosionEffect, transform.position,
                        Quaternion.identity);
            ExplosionEffect.Play();
            Debug.Log("Game Over!");
            GameSoundManager.PlayExplosion();
            Destroy(other.gameObject);
            Destroy(gameObject);
            TimeValText.text = $"Time: {TimerText.text}";
            gameManager.increaseTotalCoinsValue(gameManager.coinsCollectedPerRound);
            MoneyValText.text = $"Money: {gameManager.coinsCollectedPerRound} $ (Total: {gameManager.getTotalCoinsValue()})";
            gameManager.coinsCollectedPerRound = 0;
            RotateLeftButton.SetActive(false);
            RotateRightButton.SetActive(false);
            MachineGunButton.SetActive(false);
            MissileButton.SetActive(false);
            PauseButton.SetActive(false);
            RestartPanel.SetActive(true);
            GameTimer.HandlePlayerDeath();
        }
        else if (other.TryGetComponent<Coin>(out var coin))
        {
            gameManager.coinsCollectedPerRound++;
            CurrentMoneyValText.text = $"{gameManager.coinsCollectedPerRound}";
        }

    }
}
