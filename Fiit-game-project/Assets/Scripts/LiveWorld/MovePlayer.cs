using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour

{
    public float maxSpeed = 10f;
    private Rigidbody2D rb;
    public bool flipRight = true;
    public bool isMoving = false;
    public bool isAttack = false;
    private Animator anim;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private float jumpForce = 0.01f;

    private void SetState(StatesMove value) => anim.SetInteger("state", (int)value);

    // Start is called before the first frame update
    private void Awake()    
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        var move = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        if (move > 0 && !flipRight)
        {
            Flip();
        }
        else if (move < 0 && flipRight)
        {
            Flip();
        }
        
        if (move == 0) isMoving = false;
        
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            Jump();
        }

        if (isGrounded && !isMoving && !isAttack)
        {
            SetState(StatesMove.afk);
        }
        
        if (isGrounded && move != 0)
        {
            isMoving = true;
            SetState(StatesMove.run);
        }

        if (move == 0) isMoving = false;

        if (Input.GetMouseButtonDown(0))
        {
            isAttack = true;
            SetState(StatesMove.hitleft);
            StartCoroutine(AttackAnimation());
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            isAttack = true;
            SetState(StatesMove.hitright);
            StartCoroutine(AttackAnimation());
        }
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        SetState(StatesMove.jump);
    }
    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
    private void Flip()
    {
        flipRight = !flipRight;
        var theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    
    private IEnumerator AttackAnimation()
    {
        yield return new WaitForSeconds(0.3f);
        isAttack = false;
    }
    
}

public enum StatesMove
{
    afk,
    jump,
    run,
    hitleft,
    hitright
}