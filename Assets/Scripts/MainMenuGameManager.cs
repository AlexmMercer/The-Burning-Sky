using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuGameManager : MonoBehaviour
{
    [SerializeField] GameManager GameManager;
    [SerializeField] TextMeshProUGUI TotalCoinsText;

    private void Start()
    {
        Time.timeScale = 1.0f;
        TotalCoinsText.text = $"{GameManager.getTotalCoinsValue()}";
    }

    public void PlayClickSound()
    {
        gameObject.GetComponent<AudioSource>().Play();  
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
