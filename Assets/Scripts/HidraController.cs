using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidraController : MonoBehaviour
{
    [SerializeField] private GameObject venom;
    [SerializeField] private GameObject smoke;
    private Animator hidraAnim;
    private float attackTime;
    private float time;
    private Vector3 initpos;
    private bool isAttacking;
    private int heads = 3;
    private AudioManager audiop;
    private SceneManage scene;
    private PlayerLevel3 coru;
    

    private void Start()
    {
        coru = FindAnyObjectByType<PlayerLevel3>();
        scene = FindAnyObjectByType<SceneManage>();
        audiop = FindAnyObjectByType<AudioManager>();
        attackTime = Random.Range(6,10);
        hidraAnim = GetComponent<Animator>();  
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time > attackTime && !isAttacking)
        {
            StartCoroutine (Attack());
            time = 0;
        }
        Death();
    }
 
    private IEnumerator Attack()
    {
        isAttacking = true;
        audiop.PlaySFX(audiop.hidraAttack);
        hidraAnim.SetBool("isAtacking", true);
        yield return new WaitForSeconds(0.5f);
        initpos = transform.position + new Vector3(-33, 44, 0);
        Instantiate(venom,initpos,Quaternion.identity);
        yield return new WaitForSeconds (0.5f);
        hidraAnim.SetBool("isAtacking", false);
        attackTime = Random.Range(6,10);
        isAttacking = false;
    }

    public void Damage()
    {
        heads--;
        audiop.PlaySFX(audiop.hidraHit);
        hidraAnim.SetInteger("heads", heads);
    }

    private void Death()
    {
        if (heads < 1)
        {
            audiop.PlaySFX(audiop.hidraDeath);
            coru.HidraIsDeath();
            Destroy(smoke);
            Destroy(gameObject);
        }
    }
}
