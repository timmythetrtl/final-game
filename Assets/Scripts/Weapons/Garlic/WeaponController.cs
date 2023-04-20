using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    [Header("Weapon Stats")]
    public WeaponScriptableObject weaponData;
    public float delay;
    float currentCooldown;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        currentCooldown = weaponData.CooldownDuration;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
       
    }


    protected virtual void go()
    {
        StartCoroutine(AttackAfterDelay());
    }

    IEnumerator AttackAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        Attack();
    }

    protected virtual void Attack(){
        currentCooldown = weaponData.CooldownDuration;
    }
}
