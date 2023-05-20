using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class teleportBlue : MonoBehaviour
{
    public bool trig;
    private Transform destination;
    public float startTimeBtwTelepBlue;
    public float timeBtwTelepBlue;
    public bool teleportedBlue;
    public bool canTeleportedBlue = false;
    void Start()
    {
        timeBtwTelepBlue = startTimeBtwTelepBlue;
    }

    // Update is called once per frame
    void Update()
    {
        destination = GameObject.FindGameObjectWithTag("green").GetComponent<Transform>();
        if (GameObject.FindGameObjectWithTag("green").GetComponent<coll>().teleportedGreen)
        {
            if (timeBtwTelepBlue <= 0)
            {
                canTeleportedBlue = true;
                timeBtwTelepBlue = startTimeBtwTelepBlue;
                GameObject.FindGameObjectWithTag("green").GetComponent<coll>().teleportedGreen = false;
            }

            else
            {
                canTeleportedBlue = false;
                timeBtwTelepBlue -= Time.deltaTime;
            }
        }
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        trig = true;
        //&& Vector2.Distance(transform.position,other.transform.position) >= delta
        if (!other.gameObject.CompareTag("wall") && canTeleportedBlue)
        {
            teleportedBlue = true;
            other.transform.position = new Vector2(destination.position.x, destination.position.y);
            GameObject.FindGameObjectWithTag("green").GetComponent<coll>().teleportedGreen = true;
        }
        
        else if(!other.gameObject.CompareTag("wall") && !teleportedBlue && !GameObject.FindGameObjectWithTag("green").GetComponent<coll>().teleportedGreen)
        {
            other.transform.position = new Vector2(destination.position.x, destination.position.y);
            teleportedBlue = true;
            GameObject.FindGameObjectWithTag("green").GetComponent<coll>().teleportedGreen = true;
        }
        
    } 
    
    public void OnTriggerExit2D(Collider2D other)
    {
        trig = false;
    } 
}