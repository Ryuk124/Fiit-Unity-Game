using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class LazerUP : MonoBehaviour
{
    public float scale = 1;
    public GameObject startPoint;
    public GameObject endPoint;
    public GameObject coleso;
    public Vector2 point;
    public Vector2 normal;
    void Start()
    {

    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(startPoint.transform.position,endPoint.transform.position);
        Debug.DrawLine(startPoint.transform.position, endPoint.transform.position,Color.black);
        if (!hit.collider.GameObject().CompareTag("glass"))
        {
            point = hit.point;
            normal = hit.normal;
        }
        
        
        var distanceHit = (float)(Math.Sqrt(
            (endPoint.transform.position.x - startPoint.transform.position.x) * (endPoint.transform.position.x - startPoint.transform.position.x)
            + (endPoint.transform.position.y - startPoint.transform.position.y) * (endPoint.transform.position.y - startPoint.transform.position.y)));

        if (coleso.transform.rotation.eulerAngles.z > 350)
        {
            ScaleRayWithoutContact(point, distanceHit);
        }
        
    }

    
    
    
    public void ScaleRayWithoutContact(Vector2 point, float distanceMouse)
    {
        var length = 0.994f;
        scale = distanceMouse / length;
        Debug.Log((distanceMouse));
        Debug.Log(scale);
        startPoint.transform.localScale = new Vector2(3.116098f, scale);
    }
}