using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuGameManager : MonoBehaviour
{
    [SerializeField] GameManager GameManager;
    [SerializeField] GameObject ShopMenu;
    [SerializeField] GameObject MainButtonMenu;
    [SerializeField] TextMeshProUGUI TotalCoinsText;

    private void Start()
    {
        Time.timeScale = 1.0f;
        ShopMenu.SetActive(false);
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
}
