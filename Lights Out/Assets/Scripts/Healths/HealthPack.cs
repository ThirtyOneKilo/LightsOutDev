using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    //health to add
    public int healthAddAmount;

    //if the other object has the playerhealth component, add health and destroy the healthpack
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>() != null)
        {
            other.GetComponent<PlayerHealth>().addHealth(healthAddAmount);
            Destroy(gameObject);
        }
    }
}
