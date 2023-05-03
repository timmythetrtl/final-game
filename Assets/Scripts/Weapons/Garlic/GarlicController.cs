using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TarodevController;

public class GarlicController : WeaponController
{
    private bool isUpKeyPressed = false;
    private float spawnOffset = 1f;

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

    protected override void Update()
    {
        // Check if the up arrow key is being held down
        if (Input.GetKey(KeyCode.UpArrow))
        {
            isUpKeyPressed = true;
        }
        else
        {
            isUpKeyPressed = false;
        }
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedGarlic = Instantiate(weaponData.Prefab);
        spawnedGarlic.transform.parent = transform.parent; // set parent to Player object

        Vector3 offset = new Vector3(1.5f, 0f, 0f); // default offset to the right

        // Check if the up arrow key is being held down and adjust offset accordingly
        if (isUpKeyPressed)
        {
            offset.y = spawnOffset; // adjust offset to above player
        }

        if (transform.parent.GetComponentInChildren<SpriteRenderer>().flipX) // check if player is facing left
        {
            offset.x = -offset.x; // adjust offset to the left
            Quaternion rotation = Quaternion.Euler(0f, 180f, 0f); // rotate object 180 degrees
            spawnedGarlic.transform.rotation = rotation;
        }
        spawnedGarlic.transform.position = transform.position + offset; // set position with offset
    }

}
