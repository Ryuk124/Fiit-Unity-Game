using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMoveRight : MonoBehaviour
{
    private Rigidbody2D rbFire;
    private void Awake()
    {
        rbFire = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        rbFire.velocity = new Vector2(4, rbFire.velocity.y);
    }
}
