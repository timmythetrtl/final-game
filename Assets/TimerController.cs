using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    public float timeLimit = 30f;
    private float timer = 0f;
    private bool isRunning = false;
    public TextMeshProUGUI timerText;

    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        timerText.text = "Time: " + timeLimit.ToString();
    }

    void Update()
    {
        if (isRunning)
        {
            timer += Time.deltaTime;
            timerText.text = "Time: " + Mathf.RoundToInt(timeLimit - timer).ToString();
            if (timer >= timeLimit)
            {
                Debug.Log("Time's up!");
                isRunning = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isRunning = false;
        }
    }
}
