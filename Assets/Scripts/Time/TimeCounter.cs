using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class TimeCounter : MonoBehaviour
{
    public float elapsedTime = 0.0f;
    private TextMeshProUGUI timeText;


    void Start()
    {
        timeText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        // Calculate the minutes, seconds, and hundredths of a second components of the elapsed time
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        int hundredths = Mathf.FloorToInt((elapsedTime - Mathf.FloorToInt(elapsedTime)) * 100);

        // Format the time text using the minutes, seconds, and hundredths of a second components
        timeText.text = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, hundredths);
    }
}
