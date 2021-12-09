using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private Transform waypoint1, waypoint2;
    [SerializeField]
    private bool switching;

    [SerializeField]
    private float speed = 5f;

    private SpriteRenderer sprite;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if(distance < 5)
        {
            AttackPlayer();
            RotateTowardsTarget();
        }
        else if(distance > 5)
        {
            Movement();
        }
        
    }

    private void Movement()
    {
        if(transform.position == waypoint1.position)
        {
            switching = true;             
        }
        else if(transform.position == waypoint2.position)
        {
            switching = false;     
        }

        if(switching == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoint2.position, speed * Time.deltaTime);
            sprite.flipY = true;
        }
        else if(switching == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoint1.position, speed * Time.deltaTime);
            sprite.flipY = false;
        }
    }
    private void AttackPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void RotateTowardsTarget()
    {
        var offset = 90f;
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
        sprite.flipY = false;
    }
}
