using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    public int Width;

    public int Height;

    public int X;

    public int Y;
    // Start is called before the first frame update
    private int count = 0;

    void Start()
    {
        if(RoomController.instance == null)
        {
            Debug.Log("You pressed play in the wrong scene!");
            return;
        }

        RoomController.instance.RegisterRoom(this);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //this is where the center is
        Gizmos.DrawWireCube(transform.position, new Vector3(Width, Height, 0));
        
    }

    // Update is called once per frame
    public Vector3 GetRoomCentre()
    {
        return new Vector3(X * Width, Y * Height);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            RoomController.instance.OnPlayerEnterRoom(this);

            // Get the rigidbody of the character
            Rigidbody2D characterRigidbody = other.GetComponent<Rigidbody2D>();

            // Check if the character is moving up
            if (characterRigidbody.velocity.y > 0f)
            {
                // Get the current position of the other object
                Vector3 newPosition = other.transform.position;

                // Move the other object up by 0.5 units
                newPosition.y += 3f;

                // Update the position of the other object
                other.transform.position = newPosition;

                GameObject prefab = Resources.Load<GameObject>("Save");
                Instantiate(prefab, new Vector3(X, (Y * Height)-8.60f), Quaternion.identity);
            }
            Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, GetComponent<BoxCollider2D>().size, 0f);
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Enemy"))
                {
                    Freezer enemyFreezer = collider.GetComponent<Freezer>();
                    if (enemyFreezer != null)
                    {
                        enemyFreezer.Continue();
                    }
                }
            }
        }
        if (other.tag == "Enemy")
        {
            count++;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, GetComponent<BoxCollider2D>().size, 0f);
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Enemy"))
                {
                    Freezer enemyFreezer = collider.GetComponent<Freezer>();
                    if (enemyFreezer != null)
                    {
                        enemyFreezer.Stop();
                    }
                }
            }
        }
        else if (other.tag == "Enemy")
        {
            count--;
            if (count == 0)
            {
                GameObject block = GameObject.FindGameObjectWithTag("Block");
                if (block != null)
                {
                    Destroy(block);
                }
            }
        }
    }




}
