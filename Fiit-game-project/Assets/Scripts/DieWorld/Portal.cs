using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PortalBehaviour : MonoBehaviour
{
    
    void Start()
    {
        var portal = GameObject.Find("Portal");
        portal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        var portal = GameObject.Find("Portal");
        if (DeathCount.Enemies >= 1)
            portal.SetActive(true);
    }
}
