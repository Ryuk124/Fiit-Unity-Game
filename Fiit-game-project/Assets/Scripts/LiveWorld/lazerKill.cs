using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazerKill : MonoBehaviour
{
    public GameObject main;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && main.transform.localScale.y >= 0.7f) 
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector2(-15, 2.4f);
        }

        if (other.gameObject.CompareTag("rope"))
        {
            var key = GameObject.FindGameObjectWithTag("key");
            var lastrope = GameObject.FindGameObjectWithTag("lastRope");
            lastrope.GetComponent<HingeJoint2D>().connectedBody = lastrope.GetComponent<Rigidbody2D>();
            key.GetComponent<DistanceJoint2D>().connectedBody = key.GetComponent<Rigidbody2D>();
            key.tag = "KEY";
            Destroy(other.gameObject);
        }
    }
}
