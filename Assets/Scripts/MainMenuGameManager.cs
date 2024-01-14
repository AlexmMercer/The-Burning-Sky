using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuGameManager : MonoBehaviour
{
    [SerializeField] GameManager GameManager;
    [SerializeField] GameObject ShopMenu;
    [SerializeField] GameObject ControlMenu;
    [SerializeField] GameObject MainButtonMenu;
    [SerializeField] GameObject HintPanel;
    [SerializeField] TextMeshProUGUI TotalCoinsText;

    private void Start()
    {
        Time.timeScale = 1.0f;
        HintPanel.SetActive(false);
        ShopMenu.SetActive(false);
        ControlMenu.SetActive(false);
        TotalCoinsText.text = $"{GameManager.getTotalCoinsValue()}";
    }

    public void PlayClickSound()
    {
        gameObject.GetComponent<AudioSource>().Play();  
    }

    public void OpenShop()
    {
        ShopMenu.SetActive(true);
        MainButtonMenu.SetActive(false);
    }

    public void CloseShop()
    {
        ShopMenu.SetActive(false);
        MainButtonMenu.SetActive(true);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowPlayHint()
    {
        HintPanel.SetActive(true);
    }

    public void ClosePlayHint()
    {
        HintPanel.SetActive(false);
    }

    public void ShowSettingsPanel()
    {
        ControlMenu.SetActive(true);
    }

    public void CloseSettingsPanel()
    {
        ControlMenu.SetActive(false);
    }
}
