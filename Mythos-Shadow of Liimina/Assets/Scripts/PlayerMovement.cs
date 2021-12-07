using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    attack,
    intract
}
public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D playerRigidbody;
    private Vector3 change;
    public VectorValue startingPosition;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        transform.position = startingPosition.initValue;
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Attack") && currentState != PlayerState.attack)
        {
            StartCoroutine(AttackCo());
        }
        else if(currentState == PlayerState.walk)
        {
            UpdateAnimationAndMove();
        }
        

    }

    //Co-routine
    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;
    }
    void UpdateAnimationAndMove()
    {
        //if there is an actual change happing
        if (change != Vector3.zero)
        {

            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    ///Call Rigidbody and set to move towards the position of the current position + change 
    void MoveCharacter()
    {
        //makes movement fluent not choppy
        playerRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }
}
