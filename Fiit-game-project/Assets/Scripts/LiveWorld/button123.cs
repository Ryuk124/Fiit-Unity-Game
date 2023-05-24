using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    public GameObject button2;
    public GameObject button1;
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
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("FGDFSGDGG");
            Destroy(button1);
            Instantiate(button2, new Vector3(-30.4431f,-46.46f,0),Quaternion.identity);
        }
    }
}
