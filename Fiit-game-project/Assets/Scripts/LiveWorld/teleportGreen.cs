using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class coll : MonoBehaviour
{
    private Transform destination;
    public float startTimeBtwTelep;
    public float timeBtwTelep;
    public bool teleportedGreen;
    public bool canTeleportedGreen = false;
    void Start()
    {
        timeBtwTelep = startTimeBtwTelep;
    }

    // Update is called once per frame
    void Update()
    {
        destination = GameObject.FindGameObjectWithTag("blue").GetComponent<Transform>();
        if (GameObject.FindGameObjectWithTag("blue").GetComponent<teleportBlue>().teleportedBlue)
        {
            if (timeBtwTelep <= 0)
            {
                canTeleportedGreen = true;
                timeBtwTelep = startTimeBtwTelep;
                GameObject.FindGameObjectWithTag("blue").GetComponent<teleportBlue>().teleportedBlue = false;
            }

            else
            {
                canTeleportedGreen = false;
                timeBtwTelep -= Time.deltaTime;
            }
        }
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        //&& Vector2.Distance(transform.position,other.transform.position) >= delta
        if (!other.gameObject.CompareTag("wall") && canTeleportedGreen && !other.gameObject.CompareTag("Ground")) 
        {
            other.transform.position = new Vector2(destination.position.x, destination.position.y);
            teleportedGreen = true;
        }
        
        else if(!other.gameObject.CompareTag("wall") && !teleportedGreen && !GameObject.FindGameObjectWithTag("blue").GetComponent<teleportBlue>().teleportedBlue
                && !other.gameObject.CompareTag("Ground"))
        {
            other.transform.position = new Vector2(destination.position.x, destination.position.y);
            teleportedGreen = true;
        }
        
    } 
}
