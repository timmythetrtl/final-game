using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public BoxCollider2D Collider;
    public GameObject platform;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("MY WIN");
        if (other.tag == "Player")
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
            platform.GetComponent<BoxCollider2D>().enabled = false;
            transform.position = transform.position + new Vector3(0, 1);

        }
    }
}
