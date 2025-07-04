using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip;
    public float jumpForce = 700f;
    private int jumpCount = 0;
    private bool isGrounded = false;
    private bool isDead = false;

    private Rigidbody2D playerRigidbody;
    private Animator animator;
    private AudioSource playerAudio;
    
    public float Speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return;
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerRigidbody.AddForce(new Vector2(-Speed, 0));
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            playerRigidbody.AddForce(new Vector2(Speed, 0));
            transform.localScale = new Vector3(1, 1, 1);
           
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            playerRigidbody.AddForce(new Vector2(10f, 0));
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetKey(KeyCode.Space) && jumpCount < 2)
        {
            jumpCount++;

            playerRigidbody.linearVelocity = Vector2.zero;

            playerRigidbody.AddForce(new Vector2(0, jumpForce));
            
            playerAudio.Play();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCount = 0;
            animator.SetBool("Grounded", true);
        }

    }

    private void Die()
    {
        animator.SetTrigger("Die");
        playerAudio.clip = deathClip;
        playerAudio.Play();

        playerRigidbody.linearVelocity = Vector2.zero;
        isDead = true;
    }

    
}
