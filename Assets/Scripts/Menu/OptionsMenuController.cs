using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenuController : MonoBehaviour
{
    void Update()
    {
        // Check if the ESC key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Unload the current scene
            SceneManager.UnloadSceneAsync(gameObject.scene);
        }
    }

    public void OnBackButtonPressed()
    {
        // Call this function when the "Back" button is pressed
        SceneManager.UnloadSceneAsync(gameObject.scene);
    }
}
