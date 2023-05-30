using System;
using UnityEngine;

public class SlugJumping : MonoBehaviour
{
    public bool IsAgred;
    public bool IsJump;

    public Vector3 PlayerCoordinate;
    public Vector3 SlugCoordinate;
    public AudioSource SoundAfterJump;
    public int SlugJumpX;
    public int SlugJumpY;

    private bool flipRight = true;
    private Rigidbody2D rb;

    [SerializeField] private float jumpForce = 0.1f;
    [SerializeField] private bool isGrounded;

    private Animator anim;

    private SlugStates11 State
    {
        get => (SlugStates11)anim.GetInteger("state");
        set { anim.SetInteger("state", (int)value); }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        var player = GameObject.Find("Player");
        PlayerCoordinate = player.transform.position;
        SlugCoordinate = this.transform.position;


        if (isGrounded)
        {
            State = SlugStates11.afk;

            if (Math.Abs(SlugCoordinate.x - PlayerCoordinate.x) < SlugJumpX &&
                Math.Abs(SlugCoordinate.y - PlayerCoordinate.y - 2.65) < SlugJumpY)
            {
                IsAgred = true;
                if (SlugCoordinate.x > PlayerCoordinate.x && flipRight)
                    Flip();
                if (SlugCoordinate.x < PlayerCoordinate.x && !flipRight)
                    Flip();

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
            if (IsJump && IsAgred)
            {
                SoundAfterJump.Play();
                IsJump = false;
            }


        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground") || collision.collider.CompareTag("floor"))
        {
            State = SlugStates11.jump1;
            IsJump = true;
            isGrounded = false;
        }
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        if (flipRight)
        {
            rb.velocity = new Vector2(6, rb.velocity.y);
        }
        else rb.velocity = new Vector2(-6, rb.velocity.y);
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
