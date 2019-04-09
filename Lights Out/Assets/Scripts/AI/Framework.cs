using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Framework : MonoBehaviour
{
    //our player's position
    public Transform player;
    //navmesh component
    public NavMeshAgent agent;
    //radius of how far the enemy will view from
    public float viewDistance;
    //how close the enemy has to be to stop, or attack
    float attackDistance;
    bool pursuing = false;
    bool isIdle;
    // Start is called before the first frame update
    void Start()
    {
        //set attack distance to the stopping distance on the navmesh agent since it will be set there
        attackDistance = agent.stoppingDistance;
    }

    // Update is called once per frame
    void Update()
    {
        //update distance between player and enemy
        Vector3 direction = player.transform.position - this.transform.position;
        //make sure up/down is always 0
        direction.y = 0;

        //update where the player is, and where the enemy is
        Vector3 target = player.transform.position;
        Vector3 thisLocation = this.transform.position;
        
        //if player is within range, we MUST attack or walk
        if(Vector3.Distance(player.position, this.transform.position) < viewDistance)
        {
            if(direction.magnitude > attackDistance)
            {
                //move to target
                isIdle = false;
                agent.SetDestination(target);
                pursuing = true;
            } else if (direction.magnitude <= attackDistance)
            {
                //attack?
            }
        }
        //if the enemy is idle, then make sure it doesn't move to aother position
        if(isIdle == true)
        {
            agent.SetDestination(thisLocation);
        }
    }
}