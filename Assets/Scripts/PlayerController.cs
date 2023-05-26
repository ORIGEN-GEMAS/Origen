using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject panelDeath;
    [SerializeField] private GameObject camerat;
    [SerializeField] private GameObject player;
    [SerializeField] private float speed, jumpSpeed, cameraPositionZ;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private float offsetCameraY;

    private SceneManage sceneManager;
    private Rigidbody2D rbPlayer;
    private Transform trPlayer;
    private float dirX, cameraPositionX;
    private BoxCollider2D boxCollider;
    private Vector2 standSize;
    private Vector2 crouchSize;  
    private Vector2 standOffset; 
    private Vector2 crouchOffset; 
    private bool isCrouching = false;  
    private bool isGrounded = true;


    private void Awake()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        trPlayer = GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        sceneManager = FindAnyObjectByType<SceneManage>();
        audioManager = FindAnyObjectByType<AudioManager>();

        boxCollider = GetComponent<BoxCollider2D>();

        standSize = boxCollider.size;
        standOffset = boxCollider.offset;
        crouchSize = new Vector2(standSize.x, standSize.y / 2);  // Ajusta esto según tus necesidades
        crouchOffset = new Vector2(standOffset.x, standOffset.y / 2); 
    }

    private void Update()
    {
        camerat.transform.position = new Vector3(trPlayer.position.x, trPlayer.position.y + offsetCameraY, cameraPositionZ);
        if ((Input.GetKeyDown(KeyCode.Space) && isGrounded) || ((Input.GetKeyDown(KeyCode.Joystick1Button0) == true) && isGrounded))
        {
            Jump();
        }

        Walk();

        if (trPlayer.position.y < -0.15f)
        {
            cameraPositionX = trPlayer.position.x;
            camerat.transform.position = new Vector3(cameraPositionX, -0.15f, cameraPositionZ);
            if (trPlayer.position.y < -7f)
            {
                audioManager.PlaySFX(audioManager.death);
                panelDeath.SetActive(true);
                Destroy(player);
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && !isCrouching)
        {
            Crouch();
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow) && isCrouching)
        {
            StandUp();
        }
    }

    private void FixedUpdate()
    {
        rbPlayer.velocity = new Vector2(dirX * speed, rbPlayer.velocity.y);
    }

    /// <summary>
    /// This method is responsible for the player's jump action and animation.
    /// </summary>
    private void Jump()
    {
        animator.SetBool("IsJumping", true);
        rbPlayer.AddForce(Vector3.up * jumpSpeed, ForceMode2D.Impulse);
        audioManager.PlaySFX(audioManager.jump);
        isGrounded = false;
    }

    private void Crouch()
    {
        animator.SetBool("IsCrouching", true);
        animator.SetBool("IsStading", false);
        boxCollider.size = crouchSize;  
        boxCollider.offset = crouchOffset;  
        isCrouching = true;
    }

    private void StandUp()
    {
        animator.SetBool("IsCrouching", false);
        animator.SetBool("IsStading", true);
        boxCollider.size = standSize;  
        boxCollider.offset = standOffset; 
        isCrouching = false;
    }

    /// <summary>
    /// This method is responsible for the player's walk action and animation.
    /// </summary>
    private void Walk()
    {
        dirX = Input.GetAxis("Horizontal"); 
        Vector3 movement = new Vector3(dirX, 0, 0);

        if (dirX != 0)
        {
            trPlayer.rotation = Quaternion.Euler(0, dirX > 0 ? 0 : 180, 0);
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }

        if (movement.magnitude > 0.1f)
        {
            transform.Translate(movement.normalized * speed * Time.deltaTime, Space.World);// Move the character
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandlePlatformCollision(collision);
        HandleDeathGroundCollision(collision);
    }

    private void HandlePlatformCollision(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform") && !isGrounded)
        {
            isGrounded = true;
            animator.SetBool("IsJumping", false);
            ParticleSystem ps = GetComponent<ParticleSystem>();
            if (ps != null){
                ps.Play();
            }
        }
    }

    private void HandleDeathGroundCollision(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("d_ground"))
        {
            panelDeath.SetActive(true);
            audioManager.PlaySFX(audioManager.death);
            Destroy(player);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        if (collision.gameObject.CompareTag("Platform") && ps != null)
        {
            ps.Stop();
            ps.Clear();
        }
    }

    private IEnumerator CollectGems(float delay,string nextScene)
    {
        audioManager.PlaySFX(audioManager.takeGems);
        yield return new WaitForSeconds(delay);
        sceneManager.ChangeScence(nextScene);
    } 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gem"))
        {
            Destroy(other.gameObject);
            rbPlayer.Sleep();

            switch (sceneManager.actual)
            {
                case "Red World":
                    StartCoroutine(CollectGems(4f, "Forest"));
                    break;
                case "Forest":
                    StartCoroutine(CollectGems(4.3f, "moiras"));
                    break;
            }
        }

        if (other.gameObject.CompareTag("Frog"))
        {
            panelDeath.SetActive(true);
            audioManager.PlaySFX(audioManager.death);
            Destroy(player);
        }
    }  
}