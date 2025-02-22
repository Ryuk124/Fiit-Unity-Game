using System;
using System.Collections;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float maxSpeed = 10f;
    private bool flipRight = true;
    private Rigidbody2D rb;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private float jumpForce = 0.01f;
    private Animator anim;
    public static bool isAttacking = false;
    public bool isRecharged = true;
    public bool isMoving = false;
    public static Move Instance { get; set; }
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayers;
    public float attackRate;
    float nextAttackTime = 0f;
    [SerializeField] public AudioSource shootFromPlayer;
    [SerializeField] public AudioSource miss;
    [SerializeField] public AudioSource soundOfMove;
    [SerializeField] public AudioSource soundOfMoveOnFloor;


    private void SetState(States value) => anim.SetInteger("state", (int)value);
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isRecharged = true;
        isAttacking = false;
        Instance = this;
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

        if (Input.GetKeyDown(KeyCode.W) && isGrounded && !isAttacking)
            Jump();
        if (isGrounded && !isAttacking) SetState(States.afk);
        if (isGrounded && move != 0 && !isAttacking)
        {
            isMoving = true;
            SetState(States.run);
        }

        if (move == 0) isMoving = false;
        
        if (Input.GetButtonDown("Fire1"))
            if (isGrounded && !isAttacking && move == 0)
                if (Time.time >= nextAttackTime)
                {
                    Hit();
                    Attack();
                    nextAttackTime = Time.time + attackRate;
                }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "wall" && collision.gameObject.tag != "Border")
            isGrounded = true;
        if (collision.gameObject.tag == "floor" && isMoving)
        {
            if (soundOfMoveOnFloor.isPlaying) return;
            soundOfMoveOnFloor.Play();
            
        }
        else soundOfMoveOnFloor.Stop();
        
        if (collision.gameObject.tag == "Ground" && isMoving)
        {
            if (soundOfMove.isPlaying) return;
            soundOfMove.Play();
            
        }
        else soundOfMove.Stop();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        SetState(States.jump);
        isGrounded = false;
        soundOfMove.Stop();
        soundOfMoveOnFloor.Stop();
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void Hit()
    {
        if (isGrounded && isRecharged)
        {
            SetState(States.hit);
            isAttacking = true;
            isRecharged = false;
            

            StartCoroutine(AttackAnimation());
            StartCoroutine(AttackCoolDown());
            StartCoroutine(SoungOfMiss());
            

            
        }
    }

    void Attack()
    {
        var hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (var enemy in hitEnemies)
        {
            Debug.Log("We hit" + enemy);
            enemy.GetComponent<Enemy>().TakeDamage(1);
            StartCoroutine(SoungOfAttack());
            return;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    private IEnumerator AttackAnimation()
    {
        yield return new WaitForSeconds(0.465f);
        isAttacking = false;

    }
    
    private IEnumerator SoungOfAttack()
    {
        yield return new WaitForSeconds(0.15f);
        shootFromPlayer.Play();

    }
    
    private IEnumerator SoungOfMiss()
    {
        yield return new WaitForSeconds(0.15f);
        miss.Play();

    }

    private IEnumerator AttackCoolDown()
    {
        yield return new WaitForSeconds(attackRate);
        isRecharged = true;
    }

    private void Flip()
    {
        flipRight = !flipRight;
        var theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    
}

public enum States
{
    afk,
    jump,
    run,
    hit
}