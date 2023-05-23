using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour { 

    private Rigidbody2D rbFrog;
    private bool isGround = true;
    [SerializeField] private float minJumpForce = 4f;
    [SerializeField] private float minJumpDelay = 5f;

    [SerializeField] private float maxJumpForce = 8f;
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
    }

    /// <summary>
    /// This method is responsible for the frog's jump action.
    /// </summary>
    private void FrogJump()
    {
        if (Time.time >= nextJumpTime && isGround)
        {
            Vector3 movement = new Vector3(-0.5f, 1, 0);
            rbFrog.AddForce(movement * randomJumpForce, ForceMode2D.Impulse);
            nextJumpTime = Time.time + randomJumpDelay;
            isGround = false;
        }
    }

    public bool IsJumping()
    {
        return !isGround;
    }

    private void SetForceAndDelay()
    {
        randomJumpDelay = Random.Range(minJumpDelay, maxJumpDelay);
        randomJumpForce = Random.Range(minJumpForce, maxJumpForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isGround)
        {
            isGround = true;
        }
    }
}
