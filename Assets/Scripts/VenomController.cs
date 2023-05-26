using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenomController : MonoBehaviour
{
    Transform posFocus;

    [SerializeField] float speed; 
    private void VenomMovement()
    {
        Vector3 dir = (posFocus.position - transform.position).normalized;
        Vector3 posChange = dir * speed * Time.fixedDeltaTime;
        Debug.Log(posChange);
        gameObject.transform.position += posChange;
    }

    void Start()
    {
        posFocus = GameObject.FindGameObjectWithTag("focus").transform;
    }

    void FixedUpdate()
    {
        VenomMovement();
        KillVenom();
    }
   
    private void KillVenom()
    {
        float x = transform.position.x;
        float y = transform.position.y;

        if (x < -85.7 && x > -86.3 && y < -6.7 && y> -7.3)
        {
            Destroy(gameObject);
        }
    }
}
