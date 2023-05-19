using System;
using UnityEngine;

public class ckeletagr : MonoBehaviour
{
    [SerializeField] public AudioSource SoundOfMove;
    [SerializeField] public AudioSource soundOfHit;
    [SerializeField] public float Wait;

    [SerializeField] private bool flipRight = true;

    private bool flag = true;
    private bool firstEnter;

    private Animator animator;
    private Rigidbody2D rb;

    public Transform AttackPoint;

    public Vector3 PlayerCoordinate;
    public Vector3 SkeletCoordinate;
    public LayerMask PlayerLayers;
    public static bool Hit;
    public float AttackRange;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void SetState(SkeletonStates value) => animator.SetInteger("state", (int)value);

    void OnAttack()
    {
        var hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position,
            AttackRange, PlayerLayers);

        foreach (var player in hitEnemies)
        {
            Debug.Log("We hit" + player);
            player.GetComponent<health>().TakeDamage(2f);
        }
    }

    void Update()
    {
        var player = GameObject.Find("Player");

        PlayerCoordinate = player.transform.position;
        SkeletCoordinate = transform.position;

        SetState(SkeletonStates.Afk);

        if (Math.Abs(SkeletCoordinate.x - PlayerCoordinate.x) < 3 &&
            Math.Abs(SkeletCoordinate.y - PlayerCoordinate.y) < 2)
        {
            firstEnter = true;
            flag = false;
        }

        CheckFirstEnter();

        ControlMovement();
    }

    private void ControlMovement()
    {
        if (Math.Abs(SkeletCoordinate.x - PlayerCoordinate.x) < 13 &&
            Math.Abs(SkeletCoordinate.y - PlayerCoordinate.y) < 2 && flag)
        {
            if (SoundOfMove.isPlaying) return;
            SoundOfMove.Play();
            if (SkeletCoordinate.x > PlayerCoordinate.x && !flipRight)
                Flip();

            if (SkeletCoordinate.x < PlayerCoordinate.x && flipRight)
                Flip();

            rb.velocity = flipRight
                ? new Vector2(-2, rb.velocity.y)
                : new Vector2(2, rb.velocity.y);
        }
        else
        {
            rb.velocity = Vector2.zero;
            SoundOfMove.Stop();
        }
    }

    private void CheckFirstEnter()
    {
        if (firstEnter)
        {
            rb.velocity = Vector2.zero;
            Wait += Time.deltaTime;

            SetState(SkeletonStates.Hit);

            if (Wait >= 2.09f)
            {
                flag = true;
                Hit = true;
                firstEnter = false;
                Wait = 0f;
            }
        }
    }

    private void SoundOfHit()
    {
        soundOfHit.Play();
    }
    private void Flip()
    {
        flipRight = !flipRight;
        var theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


}
public enum SkeletonStates
{
    Afk,
    Hit,
}
