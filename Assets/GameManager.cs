using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject RestartPanel;
    void Start()
    {
        RestartPanel.SetActive(false);
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
        Application.Quit();
    }
}
