using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class telGR : MonoBehaviour
{
    public bool trig;
    public int number = 0;
    private Transform destination;
    public bool teleportedGreen;

    public bool lazerTpGreen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        destination = GameObject.FindGameObjectWithTag("blue").GetComponent<Transform>();
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("lazer") &&
            !GameObject.FindGameObjectWithTag("blue").GetComponent<telBlu>().lazerTpBlue)
        {
            lazerTpGreen = true;
        }

        else
        {
            lazerTpGreen = false;
        }
        
        if (!other.gameObject.CompareTag("wall") &&
            !other.gameObject.CompareTag("lazer"))
        {
            trig = true;
            number += 1;
        }
        
        if (!other.gameObject.CompareTag("wall") &&  
            !GameObject.FindGameObjectWithTag("blue").GetComponent<telBlu>().teleportedBlue &&
            !other.gameObject.CompareTag("lazer"))
        {
            Teleport(other);
        }
        
        else if(!other.gameObject.CompareTag("wall") && 
                GameObject.FindGameObjectWithTag("blue").GetComponent<telBlu>().teleportedBlue &&
                trig == false &&
                !other.gameObject.CompareTag("lazer"))
        {
            Teleport(other);
        }
          
        
    } 
    
    public void OnTriggerExit2D(Collider2D other)
    {
        GameObject.FindGameObjectWithTag("blue").GetComponent<telBlu>().teleportedBlue = false;
        trig = false;
        number = 0;
    }

    public void Teleport(Collider2D other)
    {
        var rot = GameObject.FindGameObjectWithTag("blue").transform.rotation.eulerAngles.z;
        //other.transform.rotation = rot;
        other.transform.position = new Vector2(destination.position.x, destination.position.y);
        var rbObject = other.GetComponent<IsTeleported>().rb;
        var speed = other.GetComponent<IsTeleported>().Speed;
        if (rot == 180)
        {
            rbObject.AddForce(transform.up * speed, ForceMode2D.Impulse);
        }
        
        else if (rot == 0)
        {
            rbObject.AddForce(-transform.up * speed, ForceMode2D.Impulse);
        }
        
        else if (rot == 90)
        { 
            Debug.Log(speed);
            if (speed >= 70)
            {
                rbObject.AddForce(transform.right * (speed + 100), ForceMode2D.Impulse);
            }
            
            else if (speed <= 20)
            {
                rbObject.AddForce(transform.right * (speed), ForceMode2D.Impulse);
            }
            
            else
            {
                rbObject.AddForce(transform.right * (speed + 30), ForceMode2D.Impulse);
            }
            
            
        }
        teleportedGreen = true;
        trig = true; 
        number = 0;
    }
}
