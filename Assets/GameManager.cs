using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject RestartPanel;
    [SerializeField] TextMeshProUGUI MissilesDestroyedNumber;
    private float missilesDestroyedNumber;
    void Start()
    {
        RestartPanel.SetActive(false);
        ResetDestroyedMissilesNumber();
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
}
