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

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
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
            transform.position = Vector2.MoveTowards(transform.position, waypoint2.position, speed);
            sprite.flipY = false;
        }
        else if(switching == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoint1.position, speed);
            sprite.flipY = true;
        }
    }
}
