using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemyScriptableObject enemyData;
    // Start is called before the first frame update
    [HideInInspector]
    public float currentMoveSpeed;
    [HideInInspector]
    public float currentHealth;
    [HideInInspector]
    public float currentDamage;
    
    void Awake(){
        currentMoveSpeed = enemyData.MoveSpeed;
        currentHealth = enemyData.MaxHealth;
        currentDamage = enemyData.Damage;
    }

    public void TakeDamage(float dmg){
        currentHealth -= dmg;

        if(currentHealth <= 0){
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {   
        if (col.tag == "Player")
        {
            PlayerStats player = col.GetComponent<PlayerStats>();
            player.TakeDamage(currentDamage);
        }
    }
}
