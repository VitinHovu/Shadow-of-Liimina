using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    private Rigidbody2D playerRigidbody;
    private Vector3 change;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        //if there is an actual change happing
        if(change != Vector3.zero)
        {
            MoveCharacter();
        }
        
    }

    ///Call Rigidbody and set to move towards the position of the current position + change 
    void MoveCharacter()
    {
        //makes movement fluent not choppy
        playerRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }
}
