using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedScan : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject timeCounterText; // Reference to the TextMeshPro UI element with the TimeCounter script
    public GameObject loadingScreenPanel; // Reference to the "Loading Screen Panel" game object

    void Start()
    {
        //Start the coroutine we define below named ExampleCoroutine.
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        // Get a reference to the CanvasGroup component on the loading screen panel
        CanvasGroup canvasGroup = loadingScreenPanel.GetComponent<CanvasGroup>();

        // Set the alpha to 1 to ensure the panel is visible
        canvasGroup.alpha = 1;

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);

        // Get a reference to the AstarPath component on your gameobject
        AstarPath astar = GetComponent<AstarPath>();

        // Call the Scan method to update the graph
        astar.Scan();

        // Instantiate the player prefab
        Instantiate(playerPrefab, new Vector3(0, 0), Quaternion.identity);

        // Fade out the loading screen panel over 0.5 seconds
        float duration = 0.5f;
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime / duration;
            yield return null;
        }

        // Disable the "Loading Screen Panel" game object
        loadingScreenPanel.SetActive(false);

        // Enable the TimeCounter script component on the TextMeshPro UI element
        TimeCounter timeCounter = timeCounterText.GetComponent<TimeCounter>();
        if (timeCounter != null)
        {
            timeCounter.enabled = true;
        }
    }
}
