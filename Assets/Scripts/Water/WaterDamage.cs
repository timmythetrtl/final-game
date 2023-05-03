using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterDamage : MonoBehaviour
{
    private float timer = 3f;
    private bool isPlayerInside = false;
    private PlayerStats playerStats;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Head"))
        {
            playerStats = collision.transform.parent.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                isPlayerInside = true;
            }
            playerStats.DrownMeter(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Head"))
        {
            isPlayerInside = false;
            timer = 3f;
            playerStats.DrownMeter(false);
        }
    }

    private void Update()
    {
        if (isPlayerInside)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                playerStats.TakeDamage(1);
            }
        }
    }
}

