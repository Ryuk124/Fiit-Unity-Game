using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animKolesa : MonoBehaviour
{
    public GameObject coleso;
    private Animator anim;
    private StatesColesa State
    {
        get => (StatesColesa)anim.GetInteger("state");
        set { anim.SetInteger("state", (int)value); }
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.rotation.eulerAngles.z > 350)
        {
           
            State = StatesColesa.start;
        }
    }

    public void Boost()
    {
        State = StatesColesa.run;    
    }
    
}

public enum StatesColesa
{
    empty,
    start,
    run
}