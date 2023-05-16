using UnityEngine;
using System.Collections;
using System;

public class ExampleScript : MonoBehaviour
{
    public GameObject hero;
    public GameObject start;
    public bool hasContact;
    public float scale = 1;
    public Vector2 point;
    public Vector2 startPoint;
    public GameObject spawnLeft;
    public GameObject spawnRight;
    private GameObject cloneGreen;
    private GameObject cloneBlue;
    public bool greenPortal = false;
    public bool bluePortal = false;
    public bool bothPortal = false;
    void Start()
    {

    }

    void Update()
    {
        
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        startPoint = new Vector2(start.transform.position.x, start.transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(start.transform.position,cursorPos - startPoint);
        Debug.DrawLine(start.transform.position, cursorPos,Color.black);
        if (hit)
        {
            point = hit.point;
            
        }
        
        
        var distanceHit = (float)(Math.Sqrt(
            (point.x - startPoint.x) * (point.x - startPoint.x)
            + (point.y - startPoint.y) * (point.y - startPoint.y)));
        
        var distanceMouse = (float)(Math.Sqrt(
            (cursorPos.x - startPoint.x) * (cursorPos.x - startPoint.x)
            + (cursorPos.y - startPoint.y) * (cursorPos.y - startPoint.y)));
        
        ScaleRayWithoutContact(point, distanceHit);
        TurnRay(point, distanceHit);
        GreenPortal(hit);
        BluePortal(hit);
        

    }

    public void GreenPortal(RaycastHit2D hit)
    {
        if (Input.GetMouseButtonDown(0) && greenPortal)
        {
            Destroy(cloneGreen);
            greenPortal = false;
        }
        
        if (Input.GetMouseButtonDown(0) && !greenPortal)
        {
            var rotate = spawnLeft.transform.eulerAngles;

            if (hit.normal.y != 0)
            {
                rotate.z = 90;
                Debug.Log(hit.normal.x);
            }

            if (hit.normal.x != 0)
            {
                rotate.z = 0;
            }

            if (hit.collider.CompareTag("wall"))
            {
                cloneGreen = Instantiate(spawnLeft, hit.point, Quaternion.Euler(rotate));
                greenPortal = true;
            }
        }
    }
    
    public void BluePortal(RaycastHit2D hit)
    {
        if (Input.GetMouseButtonDown(1) && bluePortal)
        {
            Destroy(cloneBlue);
            bluePortal = false;
        }
        
        if (Input.GetMouseButtonDown(1) && !bluePortal)
        {
            var rotate = spawnRight.transform.eulerAngles;

            if (hit.normal.y != 0)
            {
                rotate.z = 90;
                Debug.Log(hit.normal.x);
            }

            if (hit.normal.x != 0)
            {
                rotate.z = 0;
            }

            if (hit.collider.CompareTag("wall"))
            {
                cloneBlue = Instantiate(spawnRight, hit.point, Quaternion.Euler(rotate));
                bluePortal = true;
            }
        }
    }
    public void ScaleRayWithoutContact(Vector2 point, float distanceMouse)
    {
        var length = 2.527f;
        scale = distanceMouse / length;
        if (distanceMouse != 0)
        {
            if (point.x > point.x)
            {
                start.transform.localScale = new Vector2(scale, 1);
            }
            else start.transform.localScale = new Vector2(-scale, 1);
        }
    }

   
    public void TurnRay(Vector2 point, float distanceMouse)
    {
        float angleSin = (float)(Math.Asin((point.y - startPoint.y) / distanceMouse) * 180 / Math.PI);
        var rotate = start.transform.eulerAngles;
        if (startPoint.x < point.x)
        {
            rotate.z = angleSin + 180;
        }

        else
        {
            rotate.z = -angleSin;
        }
        
        start.transform.rotation = Quaternion.Euler(rotate);
    }
    
}


