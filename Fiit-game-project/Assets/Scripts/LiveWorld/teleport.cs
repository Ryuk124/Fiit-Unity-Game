using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coll : MonoBehaviour
{
    private Transform destination;
    public bool isGreen;
    public float distance;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGreen == false)
        {
            destination = GameObject.FindGameObjectWithTag("green").GetComponent<Transform>();
        }

        else
        {
            destination = GameObject.FindGameObjectWithTag("blue").GetComponent<Transform>();

        }
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("wall") && Vector2.Distance(transform.position,other.transform.position) > distance)
        {
            other.transform.position = new Vector2(destination.position.x, destination.position.y);
        }
        
        Debug.Log("dfffff");
    } 
}
