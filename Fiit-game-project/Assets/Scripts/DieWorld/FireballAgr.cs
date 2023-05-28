using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballAgr : MonoBehaviour
{
    [SerializeField] public AudioSource soundOfSpawn;

    public Vector3 playerCoordinate;
    public Vector3 fireBallCoordinate;
    public GameObject objLeft;
    public GameObject objRight;

    public GameObject placeOfSpawnLeft;
    public GameObject placeOfSpawnRight;
    
    public float startTimeBtwSpawns;
    private float timeBtwSpawns;
    private float timeSound;
    public float startTimeSound;
    
    // Start is called before the first frame update

    
    void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;
        timeSound = startTimeSound;
    }

    // Update is called once per frame
    void Update()
    {
        var player = GameObject.Find("Player");
        playerCoordinate = player.transform.position;
        fireBallCoordinate = this.transform.position;
        

        if (Math.Abs(fireBallCoordinate.x - playerCoordinate.x) < 40 &&
            Math.Abs(fireBallCoordinate.y - playerCoordinate.y) < 2)
        {
            if (timeBtwSpawns <= 0)
            {
                if (timeSound <= 0)
                {
                    soundOfSpawn.Play();
                    timeSound = startTimeSound;
                }
                else
                {
                    timeSound = startTimeSound;
                }
                
                if (fireBallCoordinate.x > playerCoordinate.x)
                {
                    Instantiate(objLeft,placeOfSpawnLeft.transform.position,Quaternion.identity);
                }
                else
                {
                    Instantiate(objRight,placeOfSpawnRight.transform.position,Quaternion.identity);
                }
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
      
    }
}
