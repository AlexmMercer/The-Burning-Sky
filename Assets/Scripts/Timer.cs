using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TimerText;
    private float startTime;
    private bool timerActive;

    void Start()
    {
        StartTimer();
    }

    void Update()
    {
        if (timerActive)
        {
            float currentTime = Time.time - startTime;

            string minutes = ((int)currentTime / 60).ToString("00");
            string seconds = (currentTime % 60).ToString("00");

            TimerText.text = minutes + ":" + seconds;
        }
    }

    public void StartTimer()
    {
        startTime = Time.time;
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;
    }

    public void RestartTimer()
    {
        StartTimer();
    }

    public void ResetTimer()
    {
        TimerText.text = "00:00";
    }

    public void HandlePlayerDeath()
    {
        StopTimer();
        ResetTimer();
    }
}
