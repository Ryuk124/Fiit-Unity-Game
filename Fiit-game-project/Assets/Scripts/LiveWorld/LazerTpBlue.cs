using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LazerTpBlue : MonoBehaviour
{
    public Vector2 point;
    public Vector2 normal;

    public float scale = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position,-transform.up);
        if (hit)
        {
            point = hit.point;
            normal = hit.normal;
            Debug.Log(point);
        }
        Debug.DrawLine(transform.position, point,Color.black);
        var distanceHit = (float)(Math.Sqrt(
            (point.x - transform.position.x) * (point.x - transform.position.x)
            + (point.y - transform.position.y) * (point.y - transform.position.y)));
        
        if (GameObject.FindGameObjectWithTag("blue").GetComponent<telBlu>().lazerTpBlue)
        {
            ScaleRayWithoutContact(distanceHit);
        }
        
        else
        {
            transform.localScale = new Vector2(0.4121f, 0.5f);
        }
        
    }
    
    public void ScaleRayWithoutContact(float distanceMouse)
    {
        var length = 0.207f;
        scale = distanceMouse / length;
        if (distanceMouse != 0)
        {
            transform.localScale = new Vector2(0.4121f, scale);
        }
    }
}
