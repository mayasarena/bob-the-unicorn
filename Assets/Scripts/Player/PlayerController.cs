using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Speed and jumping
    public float moveSpeed;
    public float normalSpeed;
    public float slowSpeed;
    public float jumpHeight;
    private Rigidbody2D rigidBody;
    private Animator anim;
    [HideInInspector]
    public bool slowDown = false;

    // Ground stuff
    private bool grounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    // Flying stuff
    [HideInInspector]
    public bool isFlying = false;
    public GameObject wings;

    // Fire powerup stuff
    public Transform firePoint;
    public GameObject fireBall;
    [HideInInspector]
    public bool hasFire = false;

    // Knockback stuff
    public float knockBack;
    [HideInInspector]
    public bool knockFromRight;
    public float knockBackLength;
    [HideInInspector]
    public float knockBackCount;
    public float disableTime;
    private float disableTimeCount;

    private AudioSource jumpAudio;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>(); // Get rigidbody component
        anim = GetComponent<Animator>();
        slowDown = false;
        isFlying = false; 
        wings.GetComponent<SpriteRenderer>().enabled = false; // Make sure wings are disabled
        jumpAudio = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer); // Check if player is on the ground
    }

    void Update()
    {
        // Knock back player 
        if (knockBackCount > 0)
        {
            disableTimeCount = disableTime;
            if (knockFromRight) // Knock to the right
            {
                rigidBody.velocity = new Vector2(knockBack, knockBack);
            }

            if (!knockFromRight) // Knock to the left
            {
                rigidBody.velocity = new Vector2(-knockBack, knockBack);
            }
            knockBackCount -= Time.deltaTime;
        }

        if (disableTimeCount > 0) // Countdown the timer
        {
            disableTimeCount -= Time.deltaTime;
        }

        // Flying powerup
        if (isFlying && grounded)
        {
            wings.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (!isFlying)
        {
            wings.GetComponent<SpriteRenderer>().enabled = false;
        }

        // Slow down player (used for ground patches)
        if (slowDown)
        {
            moveSpeed = slowSpeed;
        }

        else
        {
            moveSpeed = normalSpeed;
        }

        if (disableTimeCount <= 0) // Only allow movement when knockBack is over
        {
            if ((Input.GetKeyDown(KeyCode.Space) && grounded && !isFlying) || (Input.GetKeyDown(KeyCode.Space) && isFlying)) // See if spacebar is pressed for JUMP
            {
                jumpAudio.Play();
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpHeight);
                wings.GetComponent<SpriteRenderer>().enabled = false;
            }

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) // Move RIGHT 
            {
                rigidBody.velocity = new Vector2(moveSpeed, rigidBody.velocity.y);
                transform.localScale = new Vector3(1f, 1f, 1f);
            }     

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) // Move LEFT
            {
                rigidBody.velocity = new Vector2(moveSpeed * -1, rigidBody.velocity.y);
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }  

            if (Input.GetKeyDown(KeyCode.Return) && hasFire) // Shoot fire
            {
                Instantiate(fireBall, firePoint.position, firePoint.rotation);
            }
        }

        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x)); // Find out if Bob is moving
        anim.SetBool("Grounded", grounded); // Find out if Bob is grounded for animator
    }
}
