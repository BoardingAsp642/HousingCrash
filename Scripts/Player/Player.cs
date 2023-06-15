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
    public AudioClip audioSource;
    public Animator animator;
    private bool hasCollided = false;


    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        animator = GetComponent<Animator>();

    }




    public void Update()
    {
        if(Input.GetButtonDown("Space") && isOnGround == true)
        {
            playerRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
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
            animator.SetTrigger("StumbleTrigger");
            hasCollided = true;
        }
    }













































}
