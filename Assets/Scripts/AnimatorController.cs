using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("WalkRight", true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("WalkRight", false);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("WalkLeft", true);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("WalkLeft", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("IsJumping", true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("IsJumping", false);
        }


    }
}
