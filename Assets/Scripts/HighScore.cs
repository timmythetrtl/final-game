using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI bestTimeText;

    private void OnEnable()
    {
        // Retrieve the current time from PlayerPrefs and display it
        float currentTime = PlayerPrefs.GetFloat("currentTime");
        timeText.text = currentTime.ToString("F2") + "s";

        // Retrieve the best time from PlayerPrefs and display it
        float bestTime = PlayerPrefs.GetFloat("bestTime");
        bestTimeText.text = "Best Time: " + bestTime.ToString("F2") + "s";
    }
}
