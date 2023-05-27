using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class telBlu : MonoBehaviour
{
    public bool trig;
    public bool exit;
    private Transform destination;
    public bool teleportedBlue;
    public bool lazerTpBlue = false;
    public float deltaX;
    public float deltaY;
    public float x;
    public float y;
    void Start()
    {

    }
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("lazer") && !GameObject.FindGameObjectWithTag("green").GetComponent<telGR>().lazerTpGreen)
        {
            Debug.Log(lazerTpBlue);
            lazerTpBlue = true;
        }

        if (GameObject.FindGameObjectWithTag("green") == true)
        {
            if (!other.gameObject.CompareTag("wall") && !other.gameObject.CompareTag("Player") &&
                !other.gameObject.CompareTag("lazer") && !other.gameObject.CompareTag("key") && !other.gameObject.CompareTag("rope"))
            {
                deltaX = Mathf.Abs(other.bounds.center.x - other.bounds.max.x);
                deltaY = Mathf.Abs(other.bounds.center.y - other.bounds.max.y);
                if (GameObject.FindGameObjectWithTag("green").GetComponent<telGR>().teleportedGreen == false)
                {
                    Teleport(other);
                    
                    exit = false;
                }

                else if (GameObject.FindGameObjectWithTag("green").GetComponent<telGR>().teleportedGreen == true)
                {
                    if (exit == true || GameObject.FindGameObjectWithTag("ray").GetComponent<ExampleScript>().createNowBlue == true)
                    {
                        Teleport(other);
                        GameObject.FindGameObjectWithTag("green").GetComponent<telGR>().teleportedGreen = false;
                        exit = false;
                    }
                }
            }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("wall") && !other.gameObject.CompareTag("Player") &&
            !other.gameObject.CompareTag("lazer") && !other.gameObject.CompareTag("lazer") && !other.gameObject.CompareTag("rope") && !other.gameObject.CompareTag("key"))
        {
            if (teleportedBlue == false)
            {
                exit = true;
            }
        }
        lazerTpBlue = false;
    }

    public void Teleport(Collider2D other)
    {
        GameObject.FindGameObjectWithTag("ray").GetComponent<ExampleScript>().createNowBlue = false;
        GameObject.FindGameObjectWithTag("green").GetComponent<telGR>().exit = false;
        teleportedBlue = true;
        
        
        destination = GameObject.FindGameObjectWithTag("green").GetComponent<Transform>();
        x = destination.position.x;
        y = destination.position.y;
        var rot = GameObject.FindGameObjectWithTag("green").transform.rotation.eulerAngles.z;
        var rbObject = other.GetComponent<IsTeleported>().rb;
        var speed = other.GetComponent<IsTeleported>().Speed;
        var obj = other.gameObject;
        if (rot == 0)
        {
            other.gameObject.transform.position =
                new Vector2(x + deltaX, y);
            rbObject.AddForce(-transform.up * speed, ForceMode2D.Impulse);
        }

        else if (rot == 180)
        {
            other.gameObject.transform.position =
                new Vector2(x - deltaX, y);
            rbObject.AddForce(transform.up * speed, ForceMode2D.Impulse);
        }

        else if (rot == 90)
        {
            
            
            obj.transform.position =
                new Vector2(x, y + deltaY);
            
            rbObject.AddForce(transform.right * speed * 1.5f, ForceMode2D.Impulse);
        }

        else if (rot == 270)
        {
            other.gameObject.transform.position =
                new Vector2(x, y - deltaY);
        }
    }
}    
