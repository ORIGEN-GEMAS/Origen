using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerLevel3 : MonoBehaviour
{
    
    [SerializeField] private float jumpSpeed;
    [SerializeField] private Animator controlAnim;
    private AudioManager audiop;
    [SerializeField] private GameObject power;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject panelDeath;
    
    private float attackTime;
    private Vector3 initpos;
    private bool isGround = true;
    private bool isAttacking;
    private Rigidbody2D rbPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        controlAnim = GetComponent<Animator>();
        audiop = FindAnyObjectByType<AudioManager>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if ((Input.GetKeyDown(KeyCode.Space) && isGround))
        {
            Jump();
           
        }
        if ((Input.GetKeyDown("d") || Input.GetKeyDown(KeyCode.RightArrow)) && !isAttacking && isGround)
        {
            StartCoroutine(Attack());
        }
     
    }

    /// <summary>
    /// This method is responsible for the player's jump action and animation.
    /// </summary>
    private void Jump()
    {
        controlAnim.SetBool("IsJumping", true);
        rbPlayer.AddForce(Vector3.up * jumpSpeed, ForceMode2D.Impulse);
        //audiop.PlaySFX(audiop.jump);
        isGround = false;
        audiop.PlaySFX(audiop.jump);
        Debug.Log("Si entre");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGround = true;
            controlAnim.SetBool("IsJumping", false);
            
        }

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("venom"))
        {
            panelDeath.SetActive(true);
            audiop.PlaySFX(audiop.death);
            Destroy(player);
            Debug.Log("Me pego");
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;
        controlAnim.SetBool("isAttacking", true);
        initpos = transform.position + new Vector3(-79,-4.2f, 0);
        Instantiate(power, initpos, Quaternion.identity);
        yield return new WaitForSeconds(10f);
        yield return new WaitForSeconds(0.5f);
        controlAnim.SetBool("isAttacking", false);
        isAttacking = false;

    }


}
