using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levitate : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float distance;
    [SerializeField] private DirectionType direction;
    private Transform trObject;
    private Vector3 movement;
    private Vector3 initialPos;

    public enum DirectionType
    {
        Vertical,
        Horizontal
    }


    private void Awake()
    {
        trObject = transform;
        initialPos = trObject.position;

        if (direction == DirectionType.Vertical)
        {
            movement = Vector3.up;
        } 
        else
        {
            movement = Vector3.right;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Mathf.Sin(Time.time * speed) * distance;
        trObject.position = initialPos + movement * offset;
    }
}
