using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rbPlayer;
    private Transform trPlayer;
    private bool isGround = true;
    private float dirX;
    [SerializeField] private float speed, jumpSpeed;
    [SerializeField] private int inventory = 0;
    [SerializeField] private Animator controlAnim;


    private void Awake()
    {
        rbPlayer = GetComponent<Rigidbody>();
        trPlayer = GetComponent<Transform>();
        controlAnim = GetComponent<Animator>();
    }

    //------ Jump Method 🆙 ------//
    private void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.Space) && isGround) || ((Input.GetKeyDown(KeyCode.Joystick1Button0) == true)) && isGround)
        {
            controlAnim.SetBool("IsJumping", true);
            rbPlayer.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            isGround = false;
        }
    }

    //------ Walk Method 🚶🏻 ------//
    private void WalkAnimation()
    {

        dirX = Input.GetAxis("Horizontal");  // Get the horizontal input from the user
        Vector3 movement = new Vector3(dirX, 0, 0);

        if (dirX < 0)
        {
            trPlayer.localScale = new Vector2(-0.5f, trPlayer.localScale.y);
        }
        else
        {
            trPlayer.localScale = new Vector2(0.5f, trPlayer.localScale.y);
        }

        if (movement.magnitude > 0.1f)
        {
            transform.Translate(movement.normalized * speed * Time.deltaTime, Space.World);  // Move the character
        }

        if (dirX != 0)
        {
            controlAnim.SetBool("IsWalking", true);
        }
        else
        {
            controlAnim.SetBool("IsWalking", false);
        }
    }


    //------ Condition for it to jump only if it is touching the ground and not infinitely 🔃 ------//
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGround = true;
            controlAnim.SetBool("IsJumping", false);
        }
    }

    //------ Method to get the gems 💎 ------//
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gem"))
        {
            Destroy(other.gameObject);
            inventory++;
        }
    }
         
    private void Update()
    {
       WalkAnimation();   
    }

    private void FixedUpdate()
    {
        Jump();
        rbPlayer.MovePosition(trPlayer.position + new Vector3(dirX * speed, 0, 0));
    }
}