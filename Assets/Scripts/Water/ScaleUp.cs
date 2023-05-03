using UnityEngine;

public class ScaleUp : MonoBehaviour
{
    public float extrusionRate = 0.1f; // adjust this value to change the speed of extrusion
    public float movementSpeed = 0.1f; // adjust this value to change the speed of movement
    private float currentHeight = 0f; // the initial height of the extrusion

    void Update()
    {
        currentHeight += Time.deltaTime * extrusionRate; // increase the current height over time
        transform.localScale = new Vector3(transform.localScale.x, currentHeight, transform.localScale.z); // set the new scale of the object

        transform.position += new Vector3(0f, Time.deltaTime * movementSpeed, 0f); // move the object upwards over time
    }
}
