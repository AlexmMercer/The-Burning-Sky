using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject RestartPanel;
    [SerializeField] GameObject PausePanel;
    [SerializeField] GameObject TurnLeftButton;
    [SerializeField] GameObject TurnRightButton;
    [SerializeField] TextMeshProUGUI MissilesDestroyedNumber;
    public int coinsCollectedPerRound = 0;
    private float missilesDestroyedNumber;
    void Start()
    {
        Time.timeScale = 1.0f;
        RestartPanel.SetActive(false);
        PausePanel.SetActive(false);
        ResetDestroyedMissilesNumber();
        coinsCollectedPerRound = 0;
    }

    public void increaseTotalCoinsValue(int valueToAdd)
    {
        int newTotalCoinsValue = PlayerPrefs.GetInt("totalCoinsValue", 0);
        newTotalCoinsValue += valueToAdd;
        PlayerPrefs.SetInt("totalCoinsValue", newTotalCoinsValue);
    }

    public int getTotalCoinsValue()
    {
        return PlayerPrefs.GetInt("totalCoinsValue");
    }

    public void PlayClickSound()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }

    public int GetDestroyedMissilesNumber()
    {
        return (int)missilesDestroyedNumber;
    }

    public void SetDestroyedMissilesNumber()
    {
        MissilesDestroyedNumber.text = $"{missilesDestroyedNumber}";
    }

    public void ResetDestroyedMissilesNumber()
    {
        missilesDestroyedNumber = 0.0f;
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void PauseGame()
    {
        Time.timeScale = 0.0f;
        TurnLeftButton.SetActive(false);
        TurnRightButton.SetActive(false);
        PausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        TurnLeftButton.SetActive(true);
        TurnRightButton.SetActive(true);
        PausePanel.SetActive(false);
    }
}
