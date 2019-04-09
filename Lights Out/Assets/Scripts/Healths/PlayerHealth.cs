using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //define the maximum health and current health (public so we can modify it outside of this script
    public int maxHealth;
    public int currentHealth;

    //reference to the text that we display the health in
    public Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        //set the current health = max health
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //check if the player has no health left and if so, die
        if(currentHealth <= 0)
        {
            //die
        }

        //if the current health is more than max health, then take some away until it is equal to max health
        if(currentHealth > maxHealth)
        {
            currentHealth--;
        }

        //tell us what the current health is through text
        //we need to convert the int to string so it can be displayed in text
        healthText.text = currentHealth.ToString();
    }

    //the following are public so they can be called from outside of the script

    //function to take damage and remove health
    public void takeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
    }

    //function to receive health (health pack)
    public void addHealth (int addedHealth)
    {
        currentHealth = currentHealth + addedHealth;
    }
}
