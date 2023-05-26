using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class HidraController : MonoBehaviour
{
    [SerializeField] private GameObject venom;
    private Animator hidraAnim;
    private float attackTime;
    private Vector3 initpos;
    private bool isAttacking;
    private int heads = 3;
    private AudioManager audiop;
    

    private void Start()
    {
        audiop = FindAnyObjectByType<AudioManager>();
        attackTime = Random.Range(6,10);
        hidraAnim = GetComponent<Animator>();  
    }

    private void Update()
    {
        if (Time.time > attackTime && !isAttacking)
        {
            StartCoroutine (Attack());
        }
    }
 
    private IEnumerator Attack()
    {
        isAttacking = true;
        hidraAnim.SetBool("isAtacking", true);
        yield return new WaitForSeconds(0.5f);
        initpos = transform.position + new Vector3(-33, 44, 0);
        Instantiate(venom,initpos,Quaternion.identity);
        yield return new WaitForSeconds (0.5f);
        hidraAnim.SetBool("isAtacking", false);
        attackTime += Random.Range(6,10);
        isAttacking = false;
    }

    public void Damage()
    {
        heads--;
        audiop.PlaySFX(audiop.hidraHit);
        hidraAnim.SetInteger("heads", heads);
    }
}
