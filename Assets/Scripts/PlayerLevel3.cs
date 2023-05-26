using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerLevel3 : MonoBehaviour
{
    [Header("Player Properties")]
    [SerializeField] private float jumpSpeed = 20f;
    [SerializeField] private GameObject power;
    [SerializeField] private Vector3 attackOffset = new Vector3(10f, 12f, 0);
    [SerializeField] private float attackCooldown = 5f;

    [Header("UI")]
    [SerializeField] private GameObject panelDeath;

    private Rigidbody2D rbPlayer;
    private Animator controlAnim;
    private AudioManager audiop;

    private Vector3 initpos;
    private bool isGround = true;
    private bool isAttacking;
    private float attackTime;
    
    private void Start()
    {
        if(rbPlayer == null)
            rbPlayer = GetComponent<Rigidbody2D>();

        if(controlAnim == null)
            controlAnim = GetComponent<Animator>();

        if(audiop == null)
            audiop = FindObjectOfType<AudioManager>(); 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
            Jump();

        if ((Input.GetKeyDown("d") || Input.GetKeyDown(KeyCode.RightArrow)) && !isAttacking && isGround)
            StartCoroutine(Attack());
    }

    private void Jump()
    {
        controlAnim.SetBool("IsJumping", true);
        rbPlayer.AddForce(Vector3.up * jumpSpeed, ForceMode2D.Impulse);
        isGround = false;
        audiop.PlaySFX(audiop.jump);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
            Land();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("venom"))
            HandleDeath();
    }

    private void Land()
    {
        isGround = true;
        controlAnim.SetBool("IsJumping", false);
    }

    private void HandleDeath()
    {
        panelDeath.SetActive(true);
        audiop.PlaySFX(audiop.death);
        Destroy(gameObject);
    }

    private IEnumerator Attack()
    {
        isAttacking = true;
        audiop.PlaySFX(audiop.irisAttack);
        controlAnim.SetBool("isAttacking", true);
        initpos = transform.position + attackOffset;
        Instantiate(power, initpos, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        controlAnim.SetBool("isAttacking", false);
        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
    }
}
