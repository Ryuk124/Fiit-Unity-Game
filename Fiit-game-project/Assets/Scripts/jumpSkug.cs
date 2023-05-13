using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpskug : MonoBehaviour
{
    private bool flipRight = true;
    public bool kostl = false;
    public bool afterJump = false;
    private Rigidbody2D rb;
    
    [SerializeField] private float jumpForce = 0.1f;
    [SerializeField]private bool isGrounded = false;
    private Animator anim;
    
    public Vector3 playerCoordinate;
    public Vector3 slugCoordinate;
    
    public AudioSource soundAfterJump;
    private SlugStates11 State
    {
        get { return (SlugStates11)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }
    
    void Update()
    {
        var player = GameObject.Find("Player");
        playerCoordinate = player.transform.position;
        slugCoordinate = this.transform.position;


        if (isGrounded)
        {
            State = SlugStates11.afk;
            if (Math.Abs(slugCoordinate.x - playerCoordinate.x) < 10 && 
                Math.Abs(slugCoordinate.y - playerCoordinate.y - 2.65) < 3)
            {
                kostl = true;
                if (slugCoordinate.x > playerCoordinate.x && flipRight)
                {
                    Flip();
                }
                if (slugCoordinate.x < playerCoordinate.x && !flipRight)
                {
                    Flip();
                }
                State = SlugStates11.jump;
            }
        }
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground") || collision.collider.CompareTag("floor"))
        {
            State = SlugStates11.afk;
            isGrounded = true;
            rb.velocity = Vector2.zero;
            if (afterJump == true && kostl == true)
            {
                soundAfterJump.Play();
                afterJump = false;
            }

            
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground") || collision.collider.CompareTag("floor"))
        {
            State = SlugStates11.jump1;
            afterJump = true;
            isGrounded = false;
        }
    }
    
    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        if (flipRight)
        {
            rb.velocity = new Vector2(3, rb.velocity.y);
        }
        else rb.velocity = new Vector2(-3, rb.velocity.y);
    }
    
    private void Flip()
    {
        flipRight = !flipRight;
        var theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
public enum SlugStates11
{
    afk,
    jump,
    jump1
}
