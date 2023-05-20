using System;
using UnityEngine;

public class SlugAgr : MonoBehaviour
{
    [SerializeField] private bool isGrounded;
    [SerializeField] private float jumpForce = 0.1f;

    public Vector3 PlayerCoordinate;
    public Vector3 SlugCoordinate;


    private bool flipRight = true;
    private Rigidbody2D rigidBody;
    private Animator anim;
    private bool del;


    private SlugStates State
    {
        get => (SlugStates)anim.GetInteger("state");
        set { anim.SetInteger("state", (int)value); }
    }

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        var player = GameObject.Find("Player");
        PlayerCoordinate = player.transform.position;
        SlugCoordinate = this.transform.position;

        if (isGrounded)
        {
            State = SlugStates.afk;

            if (IsNeedToGo())
            {
                if (SlugCoordinate.x > PlayerCoordinate.x && flipRight 
                    || SlugCoordinate.x < PlayerCoordinate.x && !flipRight)
                    Flip();

                State = SlugStates.jump;
                Invoke("Delay", 1.5f);

                if (del)
                    Jump();
            }
        }
    }

    private bool IsNeedToGo()
    {
        return Math.Abs(SlugCoordinate.x - PlayerCoordinate.x) < 10 &&
               Math.Abs(SlugCoordinate.y - PlayerCoordinate.y - 2.65) < 3;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
            del = false;
            rigidBody.velocity = Vector2.zero;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
            State = SlugStates.jump1;
        }
    }

    private void Delay()
    {
        del = true;
    }

    private void Jump()
    {
        rigidBody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        rigidBody.velocity = flipRight ? new Vector2(4, rigidBody.velocity.y) 
            : new Vector2(-4, rigidBody.velocity.y);
    }

    private void Flip()
    {
        flipRight = !flipRight;
        var vectorScale = transform.localScale;
        vectorScale.x *= -1;
        transform.localScale = vectorScale;
    }
}
public enum SlugStates
{
    afk,
    jump,
    jump1
}
