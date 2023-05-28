using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shesterenkaOpen : MonoBehaviour
{
    private Animator anim;

    public GameObject luk;
    // Start is called before the first frame update
    private StatesShest State
    {
        get => (StatesShest)anim.GetInteger("state");
        set { anim.SetInteger("state", (int)value); }
    }
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (luk.GetComponent<lukopen>().open)
        {
            State = StatesShest.start;
        }
    }
}

public enum StatesShest
{
    empty,
    start,
}
