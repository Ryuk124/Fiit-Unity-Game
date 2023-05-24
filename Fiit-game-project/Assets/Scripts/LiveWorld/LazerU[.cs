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
    public int getGreenPortal;
    public int getBluePortal;
    public bool koleso = false;
    public int number = 0;
    void Start()
    {
        
    }

    void Update()
    {
        Debug.Log(getBluePortal);
        RaycastHit2D hit = Physics2D.Raycast(startPoint.transform.position,-transform.up);
        if (hit)
        {
            point = hit.point;
            normal = hit.normal;
        }
        var distanceHit = (float)(Math.Sqrt(
            (point.x - startPoint.transform.position.x) * (point.x - startPoint.transform.position.x)
            + (point.y - startPoint.transform.position.y) * (point.y - startPoint.transform.position.y)));
        
        if (coleso.transform.rotation.eulerAngles.z >= 150 && coleso.transform.rotation.eulerAngles.z <= 180)
        {
            
            ScaleRayWithoutContact(point, distanceHit);
            koleso = true;
        }

        if (koleso)
        {
            ScaleRayWithoutContact(point, distanceHit);
        }
    }
    public void ScaleRayWithoutContact(Vector2 point, float distanceMouse)
    {
        var length = 0.994f;
        scale = distanceMouse / length;
        startPoint.transform.localScale = new Vector2(3.116098f, scale);
    }
}