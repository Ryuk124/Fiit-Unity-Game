using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class telBlu : MonoBehaviour
{
    public bool trigBlue;
    private Transform destination;
    public bool teleportedBlue;
    public bool lazerTpBlue = false;
    public Vector2 normal;
    public Vector2 point;

    public int number = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        destination = GameObject.FindGameObjectWithTag("green").GetComponent<Transform>();
        
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("wall"))
        {
            trigBlue = true;
            number += 1;
        }
        
        if (!other.gameObject.CompareTag("wall") &&  
            !GameObject.FindGameObjectWithTag("green").GetComponent<telGR>().teleportedGreen)
        {
            Teleport(other);

        }
        
        else if(!other.gameObject.CompareTag("wall") && 
                GameObject.FindGameObjectWithTag("green").GetComponent<telGR>().teleportedGreen &&
                trigBlue == false)
        {
            Teleport(other);
        }
        
        
    } 
    
    public void OnTriggerExit2D(Collider2D other)
    {
        GameObject.FindGameObjectWithTag("green").GetComponent<telGR>().teleportedGreen = false;

        trigBlue = false;
        number = 0;
    }

    public void Teleport(Collider2D other)
    {
        
        var rot = GameObject.FindGameObjectWithTag("green").transform.rotation.eulerAngles.z;
        //other.transform.rotation = rot;
        other.transform.position = new Vector2(destination.position.x, destination.position.y);
        var rbObject = other.GetComponent<IsTeleported>().rb;
        var speed = other.GetComponent<IsTeleported>().Speed;
        Debug.Log(rot);
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
        
        teleportedBlue = true;
        trigBlue = true;
        number = 0;
    }
}
