using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundBut1 : MonoBehaviour
{
    public AudioSource click;
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (button.GetComponent<button>().click)
        {
            click.Play();
        } 
    }
}
