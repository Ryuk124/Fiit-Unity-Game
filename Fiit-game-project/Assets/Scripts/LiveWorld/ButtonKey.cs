using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonKey : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject button2;
    public GameObject button1;
    
    public GameObject door1;
    public GameObject door2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("KEY"))
            {
                Destroy(button1);
                Instantiate(button2, new Vector3(53.7f,-46.35f,0),Quaternion.identity);
                Instantiate(door1, new Vector3(42.5969f,-42.59f,0),Quaternion.identity);
                door2.GetComponent<Collider2D>().enabled = false;
                
            }
        }
}
