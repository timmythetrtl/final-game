using UnityEngine;
using UnityEngine.SceneManagement;

public class Winner : MonoBehaviour
{
    // Change this to the name of the scene you want to load
    public string nextSceneName;

    private TimeCounter timeCounter;
    private float bestTime = Mathf.Infinity;

    void Start()
    {
        timeCounter = FindObjectOfType<TimeCounter>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Retrieve the current best time from PlayerPrefs
            bestTime = PlayerPrefs.GetFloat("bestTime", Mathf.Infinity);

            // If the current time is lower than the best time, update PlayerPrefs
            if (timeCounter.elapsedTime < bestTime)
            {
                PlayerPrefs.SetFloat("bestTime", timeCounter.elapsedTime);
                PlayerPrefs.Save();
            }

            // Save the current time achieved by the player
            PlayerPrefs.SetFloat("currentTime", timeCounter.elapsedTime);
            PlayerPrefs.Save();

            SceneManager.LoadSceneAsync(nextSceneName);
            SceneManager.UnloadSceneAsync("BasementMain");
        }
    }
}
