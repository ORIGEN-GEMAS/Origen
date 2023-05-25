using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerController : MonoBehaviour
{
    Transform hidraFocus;
    // Start is called before the first frame update
    void Start()
    {
        hidraFocus = GameObject.FindGameObjectWithTag("hidraFocus").transform;
    }

    
    void FixedUpdate()
    {
        PowerMovement();
    }
    private void PowerMovement()
    {
        Vector3 dir = (hidraFocus.position - transform.position).normalized;
        Vector3 posChange = dir * 41 * Time.fixedDeltaTime;
        gameObject.transform.position += posChange;

      

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            other.gameObject.GetComponent <HidraController>().Damage();
            Destroy(gameObject);
        }
    }
}
