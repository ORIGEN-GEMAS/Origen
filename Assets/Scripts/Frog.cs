using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour { 

    //private Transform trFrog;
    private Rigidbody2D rbFrog;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float jumpDelay = 5f;
    private bool isJumping;
    private float nextJumpTime;

    void Awake()
    {
        rbFrog = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        FrogJump();
    }

    /// <summary>
    /// This method is responsible for the player's jump action and animation.
    /// </summary>
    private void FrogJump()
    {
        if (Time.time >= nextJumpTime)
        {
            Vector3 movement = new Vector3(-0.5f, 1, 0);
            rbFrog.AddForce(movement * jumpForce, ForceMode2D.Impulse);
            nextJumpTime = Time.time + jumpDelay;
            isJumping = true;
        }
        else
        {
            isJumping = false;
        }
    }

    public bool IsJumping()
    {
        return isJumping;
    }
}
