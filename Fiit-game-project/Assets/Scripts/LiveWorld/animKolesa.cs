using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animKolesa : MonoBehaviour
{
    private Animator anim;
    public bool oneTime = true;
    public bool boost = false;

    private StatesColesa State
    {
        get => (StatesColesa)anim.GetInteger("state");
        set { anim.SetInteger("state", (int)value); }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (transform.rotation.eulerAngles.z >= 300 && transform.rotation.eulerAngles.z <= 330 && oneTime)
        {
            oneTime = false;
            GetComponent<Animator>().enabled = true;
            State = StatesColesa.start;
            
        }

        else if((transform.rotation.eulerAngles.z < 300 || transform.rotation.eulerAngles.z > 330) && oneTime)
        {
            GetComponent<Animator>().enabled = false;
        }

        if (boost)
        {
            State = StatesColesa.boost;
            GetComponent<Collider2D>().enabled = false;
        }
    }

    public void Boost()
    {
        boost = true;
    }
    
}

public enum StatesColesa
{
    empty,
    start,
    boost
}