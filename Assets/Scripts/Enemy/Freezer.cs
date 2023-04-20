using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Freezer : MonoBehaviour
{
    public KeyCode stopKey = KeyCode.Space;
    private AIDestinationSetter destinationSetter;
    private IAstarAI ai;
    private Transform target;
    private GameObject player;

    void Start()
    {
        destinationSetter = GetComponent<AIDestinationSetter>();
        ai = GetComponent<IAstarAI>();
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform;
        }
    }

    public void Stop()
    {
        destinationSetter.target = null;
        ai.canSearch = false;
        ai.canMove = false;
    }
    public void Continue()
    {
        destinationSetter.target = player.transform;
        ai.canSearch = true;
        ai.canMove = true;

    }
}
