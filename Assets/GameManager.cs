using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject RestartPanel;
    [SerializeField] GameObject PausePanel;
    [SerializeField] TextMeshProUGUI MissilesDestroyedNumber;
    public int coinsCollectedPerRound = 0;
    private float missilesDestroyedNumber;
    private int totalCoinsValue;
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
        //PlayerPrefs.Save();
    }

    public int getTotalCoinsValue()
    {
        return PlayerPrefs.GetInt("totalCoinsValue");
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

    // Update is called once per frame
    void Update()
    {
        
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
        PausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        PausePanel.SetActive(false);
    }
}
