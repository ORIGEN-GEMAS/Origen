using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour { 

    private Rigidbody2D rbFrog;
    private bool isGround = true;
    [SerializeField] private float minJumpForce = 12f;
    [SerializeField] private float minJumpDelay = 3f;

    [SerializeField] private float maxJumpForce = 18f;
    [SerializeField] private float maxJumpDelay = 6f;

    private float nextJumpTime;
    private float randomJumpForce;
    private float randomJumpDelay;

    private void Awake()
    {
        rbFrog = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        SetForceAndDelay();
    }

    private void Update()
    {
        FrogJump();
        FindGround();
    }

    /// <summary>
    /// This method is responsible for the frog's jump action.
    /// </summary>
    private void FrogJump()
    {
        if (Time.time >= nextJumpTime && isGround)
        {
            //Movement set direction, it confirms gravityScale =1, next jumpTime is setting
            Vector3 movement = new Vector3(-0.5f, 1, 0);
            rbFrog.AddForce(movement * randomJumpForce, ForceMode2D.Impulse);
            rbFrog.gravityScale = 1;
            nextJumpTime = Time.time + randomJumpDelay;
            isGround = false;
        }
    }

    

    private void SetForceAndDelay()
    {
        randomJumpDelay = Random.Range(minJumpDelay, maxJumpDelay);
        randomJumpForce = Random.Range(minJumpForce, maxJumpForce);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (!isGround)
    //    {
    //        isGround = true;
    //    }
    //}

    private void FindGround()
    {
        float ypos = transform.position.y;

        if ( ypos <= 0.65f) 
        {
            
            rbFrog.gravityScale = 0;
            rbFrog.velocity = Vector3.zero;
            isGround = true;
            transform.position = new Vector3(transform.position.x, 0.66f, transform.position.z);
        }
    }
}

