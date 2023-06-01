using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeStartAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public float CurrentTime;
    private float seconds;
    private float timer;
    void Update()
    {
        timer += Time.deltaTime;
        seconds = timer % 60;
        CurrentTime += Time.fixedDeltaTime;
        if (seconds >=15)
            SceneManager.LoadScene("NewStart");
        Debug.Log(seconds);
    }
}
