using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMovement : MonoBehaviour
{
    [SerializeField]
    private bool flipRight = true;

    public Vector3 PlayerCoordinate;
    public Vector3 FireCoordinate;

    private Rigidbody2D rbFire;
    private bool turn;


    void Start()
    {
        var player = GameObject.Find("Player");
        PlayerCoordinate = player.transform.position;
        FireCoordinate = this.transform.position;

        if (PlayerCoordinate.x < FireCoordinate.x)
            turn = false;
        else
            turn = true;
    }

    void Update()
    {
        if (turn)
        {
            rbFire.velocity = new Vector2(4, rbFire.velocity.y);

            if (flipRight)
                Flip();
        }
        else
        {
            rbFire.velocity = new Vector2(-4, rbFire.velocity.y);

            if (!flipRight)
                Flip();
        }
        
    }

    private void Awake()
    {
        rbFire = GetComponent<Rigidbody2D>();
    }
    
    private void Flip()
    {
        flipRight = !flipRight;
        var theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
