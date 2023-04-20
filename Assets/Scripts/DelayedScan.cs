using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedScan : MonoBehaviour
{
    void Start()
    {
        //Start the coroutine we define below named ExampleCoroutine.
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);

        // Get a reference to the AstarPath component on your gameobject
        AstarPath astar = GetComponent<AstarPath>();

        // Call the Scan method to update the graph
        astar.Scan();


        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
    
}
