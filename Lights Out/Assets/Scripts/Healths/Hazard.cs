using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    //how much damage the object this is attatched to does
    public int damageAmount;

    //how long we wait for cooldown
    public float coolDownTime;

    //for if we decide to use a cooldown (true off the bat)
    public bool canDamage = true;

    //determine whether the hazard destroys itself after giving damage
    public bool destroyAfterDamage;

    //when something enters the object's collider (which is marked as trigger) 
    //it calls code within this function IF it can take damage and it has a player health component
    private void OnTriggerEnter(Collider other)
    {
        if (canDamage == true && other.GetComponent<PlayerHealth>() != null)
        {
            other.GetComponent<PlayerHealth>().takeDamage(damageAmount);
            if (destroyAfterDamage == true)
            {
                Destroy(gameObject);
            }
            else
            {
                StartCoroutine(damageCooldown());
            }
        }
    }

    //this is a special function, don't worry too much about it to learn. 
    //basically it allows us to use time intervals
    //that way we can make it so the player can't be damaged while under cooldown, 
    //wait for cooldown, then make damage possible
    IEnumerator damageCooldown ()
    {
        canDamage = false;
        yield return new WaitForSeconds(coolDownTime);
        canDamage = true;
    }
}
