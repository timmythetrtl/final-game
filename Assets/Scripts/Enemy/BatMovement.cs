using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMovement : MonoBehaviour
{
    private Transform target; // The target object that the BatMovement object will follow
    private Collider2D col; // Collider component on the BatMovement object
    public EnemyScriptableObject enemyData;
    EnemyStats enemy;
    

    void Start()
    {
        enemy = GetComponent<EnemyStats>();
        // Find the first object in the scene with the PlayerController script attached to it and set it as the target
        GameObject targetObject = GameObject.Find("Player");
        if (targetObject != null)
        {
            target = targetObject.transform;
        }
        else
        {
            Debug.LogError("BatMovement could not find a target with PlayerController script attached.");
        }

        // Get the collider component on the BatMovement object
        col = GetComponent<Collider2D>();

        // Ignore collisions between the bat and the player
        Physics2D.IgnoreCollision(col, targetObject.GetComponent<Collider2D>());
    }

    void Update()
    {
        // Move the BatMovement object towards the target object
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, enemy.currentMoveSpeed * Time.deltaTime);
        }
    }
}
