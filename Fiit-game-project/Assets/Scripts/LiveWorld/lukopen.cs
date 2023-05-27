using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lukopen : MonoBehaviour
{
    private Animator anim;
    public bool open = false;
    // Start is called before the first frame update
    private StatesLuk State
    {
        get => (StatesLuk)anim.GetInteger("state");
        set { anim.SetInteger("state", (int)value); }
    }
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            State = StatesLuk.start;
        }
    }
}

public enum StatesLuk
{
    empty,
    start,
}
