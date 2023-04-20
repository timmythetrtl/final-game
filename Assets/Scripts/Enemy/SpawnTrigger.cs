using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    // Called when a Collider2D other enters the trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Loop through all child objects of this game object
            for (int i = 0; i < transform.childCount; i++)
            {
                // Activate each child object
                transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
}