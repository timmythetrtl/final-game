using System.Collections;
using UnityEngine;

public class FadeAndDestroy : MonoBehaviour
{
    private float lifetime = 1.5f; // The amount of time in seconds the object should exist
    private float fadeDuration = .5f; // The duration of each fade in/out cycle
    private float alpha = 1f; // The current alpha value of the object
    private bool fadingOut = true; // Whether the object is currently fading out or not

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Start the fading coroutine
        StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
        while (true)
        {
            // Wait for the object to exist for the lifetime
            yield return new WaitForSeconds(lifetime);

            // Destroy the object
            Destroy(gameObject);

            // Exit the coroutine
            yield break;
        }
    }

    private void Update()
    {
        // Calculate the new alpha value based on the current time and fade direction
        if (fadingOut)
        {
            alpha -= Time.deltaTime / fadeDuration;
            if (alpha <= 0f)
            {
                alpha = 0f;
                fadingOut = false;
            }
        }
        else
        {
            alpha += Time.deltaTime / fadeDuration;
            if (alpha >= 1f)
            {
                alpha = 1f;
                fadingOut = true;
            }
        }

        // Set the new alpha value for the sprite renderer
        Color spriteColor = spriteRenderer.color;
        spriteColor.a = alpha;
        spriteRenderer.color = spriteColor;
    }
}

