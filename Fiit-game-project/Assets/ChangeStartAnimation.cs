using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeStartAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public float CurrentTime;
    void Update()
    {
        CurrentTime += Time.fixedDeltaTime;
        if (CurrentTime >= 270)
            SceneManager.LoadScene("NewStart");
        Debug.Log(CurrentTime);
    }
}
