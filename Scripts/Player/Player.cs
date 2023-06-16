using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variables
    public float speed;
    public float verticalInput;
    //Player Components
    public Rigidbody2D playerRB;
    public float jumpForce;
    public bool gameOver = false;
    //public float gravityModdifier;
    public bool isOnGround = true;
    //GameManager
    private GameManager gameManager;
    //General
    public AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip hitSound;
    public AudioClip pointSound;
    public Animator animator;
    private bool hasCollided = false;


    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

    }

    // Called when the player jumps
    public void Jump()
    {
        // Play the jump sound effect
        audioSource.PlayOneShot(jumpSound);
    }

    //Caleed when the player gets a point
    public void Point()
    {
        // Play the point sound effect
        audioSource.PlayOneShot(pointSound);
    }


    // Called when the player collides with an obstacle
    public void CollideWithObstacle()
    {
        // Play the obstacle collision sound effect
        audioSource.PlayOneShot(hitSound);
    }



    public void Update()
    {
        if(Input.GetButtonDown("Space") && isOnGround == true)
        {
            playerRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            Jump();
            isOnGround = false;
        }
        else if(Input.GetButtonDown("Space") && isOnGround == false)
        {
            return;
        }
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }


        if (collision.gameObject.CompareTag("Obstacle") && !animator.GetBool("hasCollided"))
        {
            gameManager.TakeDamage(1);
            animator.SetTrigger("StumbleTrigger");
            animator.SetBool("hasCollided", true);
            CollideWithObstacle();
        }
        else
        {
            animator.SetBool("hasCollided", false);
        }


        if (collision.gameObject.CompareTag("House"))
        {
            gameManager.TakeDamage(5);
        }


        if (collision.gameObject.CompareTag("Point"))
        {
            gameManager.AddPoint();
            Point();
            Destroy(collision.gameObject);
        }
    }













































}
