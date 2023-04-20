using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TarodevController;

public class GarlicController : WeaponController
{

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        // Find the player object in the scene
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            // Get the PlayerController component from the player object
            PlayerController playerController = player.GetComponent<PlayerController>();
            if (playerController != null)
            {
                // Subscribe to the Attacked event
                playerController.Attacked += go;
            }
        }
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedGarlic = Instantiate(weaponData.Prefab);
        spawnedGarlic.transform.parent = transform.parent; // set parent to Player object

        Vector3 offset = new Vector3(1f, 0f, 0f); // default offset to the right
        if (transform.parent.GetComponentInChildren<SpriteRenderer>().flipX) // check if player is facing left
        {
            offset.x = -offset.x; // adjust offset to the left
            Quaternion rotation = Quaternion.Euler(0f, 180f, 0f); // rotate object 180 degrees
            spawnedGarlic.transform.rotation = rotation;
        }
        spawnedGarlic.transform.position = transform.position + offset; // set position with offset
    }

}

