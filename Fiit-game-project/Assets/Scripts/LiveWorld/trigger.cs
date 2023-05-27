using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public GameObject key;

    public Rigidbody2D lastRope;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("lazer"))
        {
            Debug.Log("AAAAAAAAAAAAAAA");
            key.GetComponent<DistanceJoint2D>().connectedBody = lastRope;
            key.tag = "KEY";
            Destroy(this.gameObject);
            
        }
        
        
    }
}
