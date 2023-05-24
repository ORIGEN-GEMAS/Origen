using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenomController : MonoBehaviour
{
    Transform PosPlayer;

    [SerializeField] float speed;  
    

    void Start()
    {
        PosPlayer = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        VenomMovement();
    }

    private void VenomMovement()
    {
        Vector3 mapPos = PosPlayer.position;
        Vector3 posChange = Vector3.Lerp(transform.position, mapPos, 0.75f) * Time.fixedDeltaTime;
        transform.position += posChange;
        //posChange.x 

    }
}
