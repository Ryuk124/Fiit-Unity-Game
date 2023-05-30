using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class telGR : MonoBehaviour
{
    public bool trig;
    public bool exit;
    private Transform destination;
    public bool teleportedGreen;
    public bool lazerTpGreen;
    public float deltaX;
    public float deltaY;
    public float x;
    public float y;

    public GameObject main;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("lazer") && !GameObject.FindGameObjectWithTag("blue").GetComponent<telBlu>().lazerTpBlue)
        {
            lazerTpGreen = true;
        }
        if (GameObject.FindGameObjectWithTag("blue") == true && main.transform.localScale.y <= 0.7f)
        {
            if (!other.gameObject.CompareTag("wall") && !other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("lazer") && !other.gameObject.CompareTag("key") 
                && !other.gameObject.CompareTag("rope") && !other.gameObject.CompareTag("Ground"))
            {
                deltaX = Mathf.Abs(other.bounds.center.x - other.bounds.max.x);
                deltaY = Mathf.Abs(other.bounds.center.y - other.bounds.max.y);
                trig = true;
                if (GameObject.FindGameObjectWithTag("blue").GetComponent<telBlu>().teleportedBlue == false)
                {
                    Teleport(other);
                    exit = false;
                }
            
                else if (GameObject.FindGameObjectWithTag("blue").GetComponent<telBlu>().teleportedBlue == true)
                {
                    if (exit == true || GameObject.FindGameObjectWithTag("ray").GetComponent<ExampleScript>().createNowGreen == true)
                    {
                        Teleport(other);
                        GameObject.FindGameObjectWithTag("blue").GetComponent<telBlu>().teleportedBlue = false;
                        trig = false;
                        exit = false;
                    }
                }
                
            
            }
        }
    } 
    
    public void OnTriggerExit2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("wall") && !other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("lazer") 
            && !other.gameObject.CompareTag("rope") && !other.gameObject.CompareTag("key") && !other.gameObject.CompareTag("Ground"))
        {
            if (teleportedGreen == false)
            {
                exit = true;
            }
        }
        
        lazerTpGreen = false;

    }

    public void Teleport(Collider2D other)
    {
        GameObject.FindGameObjectWithTag("ray").GetComponent<ExampleScript>().createNowGreen = false;
        GameObject.FindGameObjectWithTag("blue").GetComponent<telBlu>().exit = false;
        teleportedGreen = true;
        
        
        destination = GameObject.FindGameObjectWithTag("blue").GetComponent<Transform>();
        x = destination.position.x;
        y = destination.position.y;
        var rot = GameObject.FindGameObjectWithTag("blue").transform.rotation.eulerAngles.z;
        var rbObject = other.GetComponent<IsTeleported>().rb;
        var speed = other.GetComponent<IsTeleported>().Speed;
        if (rot == 0)
        {
            other.gameObject.transform.position = new Vector2(x + deltaX + 3, y);
            rbObject.AddForce(-transform.up * speed, ForceMode2D.Impulse);
        }
        
        else if (rot == 180)
        {
            other.gameObject.transform.position = new Vector2(x - deltaX - 3, y);
            rbObject.AddForce(transform.up * speed, ForceMode2D.Impulse);
        }
        
        else if (rot == 90)
        {
            
            other.gameObject.transform.position = new Vector2(x, y + deltaY + 3);
            rbObject.AddForce(transform.right * speed*1.5f, ForceMode2D.Impulse);
        }
        
        else if (rot == 270)
        {
            other.gameObject.transform.position = new Vector2(x, y - deltaY - 3);
        }
        
        
    }
}

