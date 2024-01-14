using System;
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
    [SerializeField] GameObject MachineGunButton;
    [SerializeField] GameObject MissileButton;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject PlayerMissilePrefab;
    [SerializeField] TextMeshProUGUI MissilesDestroyedNumber;
    public int coinsCollectedPerRound = 0;
    private float missilesDestroyedNumber;
    private int canUseMachineGun = 0;
    private int missilePositionIndex = 0;
    private int canUseUnguidedMissiles = 0;
    private List<GameObject> playerUnguidedMissiles = new List<GameObject>();
    void Start()
    {
        Time.timeScale = 1.0f;
        Debug.Log(Convert.ToBoolean(canUseMachineGun));
        MachineGunButton.SetActive(Convert.ToBoolean(PlayerPrefs.GetInt("canUseMachineGun", 0)));
        MissileButton.SetActive(Convert.ToBoolean(PlayerPrefs.GetInt("canUseUnguidedMissiles", 0)));
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

    public void decreaseTotalCoinsValue(int valueToSubtract)
    {
        int newTotalCoinsValue = PlayerPrefs.GetInt("totalCoinsValue", 0);
        newTotalCoinsValue -= valueToSubtract;
        PlayerPrefs.SetInt("totalCoinsValue", newTotalCoinsValue);
    }

    public void allowToUseMachineGun()
    {
        int canUseM2 = PlayerPrefs.GetInt("canUseMachineGun", 0);
        canUseM2 = 1;
        PlayerPrefs.SetInt("canUseMachineGun", canUseM2);
    }
    public void allowToUseUnguidedMissiles()
    {
        int canUseUMissiles = PlayerPrefs.GetInt("canUseUnguidedMissiles", 0);
        canUseUMissiles = 1;
        PlayerPrefs.SetInt("canUseUnguidedMissiles", canUseUMissiles);
    }

    public int getTotalCoinsValue()
    {
        return PlayerPrefs.GetInt("totalCoinsValue", 0);
    }

    public int getSummaryAmmoValue()
    {
        return PlayerPrefs.GetInt("SummaryAmmo", 0);
    }

    public int getSummaryUnguidedMissilesValue()
    {
        return PlayerPrefs.GetInt("SummaryUnguidedMissilesValue", 0);
    }

    public List<GameObject> getUnguidedMissiles()
    {
        return playerUnguidedMissiles;
    }

    public void resetSummaryUnguidedMissilesValue()
    {
        PlayerPrefs.SetInt("SummaryUnguidedMissilesValue", 0);
    }

    public void increaseSummaryUnguidedMissilesValue()
    {
        if(getSummaryUnguidedMissilesValue() < 6)
        {
            PlayerPrefs.SetInt("SummaryUnguidedMissilesValue", getSummaryUnguidedMissilesValue() + 1);
        }
    }

    public void setSummaryAmmoValue(int val)
    {
        PlayerPrefs.SetInt("SummaryAmmo", val);
    }

    public void addAmmo(int valueToAdd)
    {
        int currentAmmo = PlayerPrefs.GetInt("SummaryAmmo");
        currentAmmo += valueToAdd;
        PlayerPrefs.SetInt("SummaryAmmo", currentAmmo);
    }

    public void addUnguidedMissile()
    {
        if (missilePositionIndex >= 6) missilePositionIndex = 0;
        GameObject[] missilePositions = GameObject.FindGameObjectsWithTag("MissileSlot");
        var newMissile = Instantiate(PlayerMissilePrefab, missilePositions[missilePositionIndex].transform.position, PlayerMissilePrefab.transform.rotation);
        newMissile.transform.SetParent(missilePositions[missilePositionIndex].transform);
        playerUnguidedMissiles.Add(newMissile);
        missilePositionIndex++;
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
        Player.GetComponent<AudioSource>().Stop();
        TurnLeftButton.SetActive(false);
        TurnRightButton.SetActive(false);
        MachineGunButton.SetActive(false);
        MissileButton.SetActive(false);
        PausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Player.GetComponent<AudioSource>().Play();
        Time.timeScale = 1.0f;
        TurnLeftButton.SetActive(true);
        TurnRightButton.SetActive(true);
        MachineGunButton.SetActive(true);
        MissileButton.SetActive(true);
        PausePanel.SetActive(false);
    }
}
