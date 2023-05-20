using System;
using UnityEngine;

public class SkeletonAgr : MonoBehaviour
{
    [SerializeField] public AudioSource SoundOfMove;
    [SerializeField] public AudioSource SoundOfHit;
    [SerializeField] public float Wait;

    [SerializeField] private bool flipRight = true;

    public static bool Hit;
    public Transform AttackPoint;
    public Vector3 PlayerCoordinate;
    public Vector3 SkeletCoordinate;
    public LayerMask PlayerLayers;
    public float AttackRange;

    private bool flag = true;
    private bool firstEnter;
    private Animator animator;
    private Rigidbody2D rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
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
            player.GetComponent<Health>().TakeDamage(2f);
        }
    }

    void Update()
    {
        var player = GameObject.Find("Player");

        PlayerCoordinate = player.transform.position;
        SkeletCoordinate = transform.position;

        SetState(SkeletonStates.Afk);

        if (IsNeedToGo(3, 2))
        {
            firstEnter = true;
            flag = false;
        }

        CheckFirstEnter();
        ControlMovement();
    }

    private bool IsNeedToGo(int distanceX, int distanceY)
    {
        return Math.Abs(SkeletCoordinate.x - PlayerCoordinate.x) < distanceX &&
               Math.Abs(SkeletCoordinate.y - PlayerCoordinate.y) < distanceY;
    }

    private void ControlMovement()
    {
        if (IsNeedToGo(13, 2) && flag)
        {
            if (SoundOfMove.isPlaying) 
                return;

            SoundOfMove.Play();

            if (SkeletCoordinate.x > PlayerCoordinate.x && !flipRight 
                || SkeletCoordinate.x < PlayerCoordinate.x && flipRight)
                Flip();

            rigidBody.velocity = flipRight
                ? new Vector2(-2, rigidBody.velocity.y)
                : new Vector2(2, rigidBody.velocity.y);
            return;
        }

        rigidBody.velocity = Vector2.zero;
        SoundOfMove.Stop();
    }

    private void CheckFirstEnter()
    {
        if (firstEnter)
        {
            rigidBody.velocity = Vector2.zero;
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

    private void PlayHitSound()
    {
        SoundOfHit.Play();
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
