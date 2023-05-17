using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private SceneManage scena;
    private Rigidbody2D rbPlayer;
    private Transform trPlayer;
    private bool isGround = true;
    private float dirX;
    [SerializeField] private float speed, jumpSpeed;

    /// <summary>
    /// Player's inventory count. It counts the gems that the player has.
    /// </summary>
    [SerializeField] private int inventory = 0;
    [SerializeField] private Animator controlAnim;
    [SerializeField] private AudioManager audiop;

    private void Start()
    {
        scena = FindAnyObjectByType<SceneManage>();
        audiop = FindAnyObjectByType<AudioManager>();
    }

    private void Awake()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        trPlayer = GetComponent<Transform>();
        controlAnim = GetComponent<Animator>();
    }
    
    /// <summary>
    /// This method is responsible for the player's jump action and animation.
    /// </summary>
    private void Jump()
    {
        controlAnim.SetBool("IsJumping", true);
        rbPlayer.AddForce(Vector3.up * jumpSpeed, ForceMode2D.Impulse);
        audiop.PlaySFX(audiop.jump);
        isGround = false;
    }

    /// <summary>
    /// This method is responsible for the player's walk action and animation.
    /// </summary>
    private void Walk()
    {
        dirX = Input.GetAxis("Horizontal");  // Get the horizontal input from the user
        Vector3 movement = new Vector3(dirX, 0, 0);

        if (dirX != 0)
        {
            trPlayer.rotation = Quaternion.Euler(0, dirX > 0 ? 0 : 180, 0);
            controlAnim.SetBool("IsWalking", true);
        }
        else
        {
            controlAnim.SetBool("IsWalking", false);
        }

        if (movement.magnitude > 0.1f)
        {
            transform.Translate(movement.normalized * speed * Time.deltaTime, Space.World);// Move the character
        }
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
        if (other.gameObject.CompareTag("Gem"))
        {
            Destroy(other.gameObject);
            inventory++;
            scena.ChangeScence("Forest");

        }
    }
         
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Jump();
        }
            
        Walk();
       
        if (trPlayer.position.y < -2)
        {
            scena.Restart();
        }
    }

    private void FixedUpdate()
    {
        rbPlayer.velocity = new Vector2(dirX * speed, rbPlayer.velocity.y);
    }
}