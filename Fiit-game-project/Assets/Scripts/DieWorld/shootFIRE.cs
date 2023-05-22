using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFire : MonoBehaviour
{
    [SerializeField]private float damage = 3f;

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.name == "Player")
        {
            otherCollider.GetComponent<Health>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (otherCollider.tag == "wall" || otherCollider.tag == "Ground")
            Destroy(gameObject);

    }
}