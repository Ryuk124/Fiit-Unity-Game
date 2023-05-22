using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private float damage = 3f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
            other.GetComponent<Health>().TakeDamage(damage);
    }
}
