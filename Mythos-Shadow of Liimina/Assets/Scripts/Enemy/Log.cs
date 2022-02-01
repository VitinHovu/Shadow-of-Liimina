/*Log.cs
 * Date Created:01-31-2022
 * 
 * Last Updated: 01-31-2022
 * by Hector
 * 
 * Script is for enemy Log 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy
{
    public Transform target;
    //insde the radius log will chase the player
    public float chaseRadius;
    //inside the radius log will attack the player
    public float attackRadius;
    //if player is outside of chase radius log will go back to its home target and go back to sleep
    public Transform homePosition;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    /// <summary>
    /// Find the distance from log to the player
    /// </summary>
    void CheckDistance()
    {
        //check the distance between player position and log position then move towards player position and stop
        // when its in the attack radius
        if(Vector3.Distance(target.position,transform.position) <= chaseRadius && 
                            Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }
}
