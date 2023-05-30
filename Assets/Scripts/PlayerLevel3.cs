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
    [SerializeField] private GameObject gem1;
    [SerializeField] private GameObject gem2;
    [SerializeField] private GameObject textGem;


    private Rigidbody2D rbPlayer;
    private Animator controlAnim;
    private Animator shoot1;
    private Animator shoot2;
    private AudioManager audiop;
    private SceneManage scene;
    private SceneTransition sceneTransition;

    private Vector3 initpos;
    public bool isGround = true;
    public bool isAttacking;
    private float attackTime;
    
    private void Start()
    {
        sceneTransition = FindAnyObjectByType<SceneTransition>();
        if(rbPlayer == null)
            rbPlayer = GetComponent<Rigidbody2D>();

        if(controlAnim == null)
            controlAnim = GetComponent<Animator>();

        if(audiop == null)
            audiop = FindObjectOfType<AudioManager>();
        
        if(scene == null)
            scene = FindObjectOfType<SceneManage>();

        if(shoot1==null)
            shoot1 = gem1.GetComponent<Animator>();
        
        if(shoot2==null)
            shoot2 = gem2.GetComponent<Animator>();
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
        shoot1.SetBool("IsShooting", true);
        shoot2.SetBool("IsShooting", true);
        textGem.SetActive(false);
        initpos = transform.position + attackOffset;
        Instantiate(power, initpos, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        controlAnim.SetBool("isAttacking", false);
        yield return new WaitForSeconds(attackCooldown);
        shoot1.SetBool("IsShooting", false);
        shoot2.SetBool("IsShooting", false);
        textGem.SetActive(true);
        isAttacking = false;
    }
    public void HidraIsDeath()
    {
        isGround = false;
        StartCoroutine(ChangetoFinal());
    }
    private IEnumerator ChangetoFinal()
    {
        audiop.PlaySFX(audiop.victory);
        yield return new WaitForSeconds(8f);
        Debug.Log("cambie");
        sceneTransition.Startcorutina("HumanCovert");
        //scene.ChangeScence("HumanCovert");
    }
}
