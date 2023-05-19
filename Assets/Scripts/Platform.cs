using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float speed; // The speed at which the platform moves
    [SerializeField] private float distance; // The distance the platform can move
    [SerializeField] private DirectionType direction; // The direction in which the platform moves
    private Vector3 movement; // The vector direction of the movement
    private Vector3 initialPos; // The initial position of the platform

    // Enum to specify the direction of the platform movement
    public enum DirectionType
    {
        Vertical,
        Horizontal
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        // If the colliding object has the tag "Player", set the platform as its parent
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // If the object leaving the collision has the tag "Player", remove the platform as its parent
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(null);
        }
    }

    private void Awake()
    {
        // Store the initial position of the platform
        initialPos = transform.position;

        // Set the movement direction based on the direction type
        movement = direction == DirectionType.Vertical ? Vector3.up : Vector3.right;
    }

    void Update()
    {
        // Calculate the offset for the platform movement
        float offset = Mathf.Sin(Time.time * speed) * distance;
        // Update the platform position
        transform.position = initialPos + movement * offset;
    }
}