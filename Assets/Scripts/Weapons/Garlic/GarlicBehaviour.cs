using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarlicBehaviour : MonoBehaviour
{
    public float destroyAfterSeconds;
    public WeaponScriptableObject weaponData;

    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected int currentPierce;

    void Awake(){
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CooldownDuration;
        currentPierce = weaponData.Pierce;
    }

    void Start()
    {
        StartCoroutine(DestroyAfterDelay());
    }

    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(destroyAfterSeconds);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Enemy")){
            EnemyStats enemy = col.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage);
        }
    }
}
