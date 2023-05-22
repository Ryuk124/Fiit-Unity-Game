using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSounds : MonoBehaviour
{
    [SerializeField] public AudioSource soundOfDieBonic;
    [SerializeField] public AudioSource soundOfDieSlug;
    [SerializeField] public AudioSource soundOfDieFireBall;
    [SerializeField] public AudioSource soundOfDiePlayer;

    private GameObject[] bonics;
    private GameObject[] slugs;
    private GameObject[] fireballs;

    void Start()
    {
        bonics = GameObject.FindGameObjectsWithTag("Bonic");
        slugs = GameObject.FindGameObjectsWithTag("slug");
        fireballs = GameObject.FindGameObjectsWithTag("fireBall");
        Debug.Log(fireballs);
    }

    void Update()
    {
        DieFireBall();
        DieBonic();
        DieSlug();
    }

    public void DieBonic()
    {
        PlayDeathSound(bonics, soundOfDieBonic);
    }

    private void PlayDeathSound(GameObject[] mobs, AudioSource deathSound)
    {
        foreach (var mob in mobs)
        {
            if (mob != null)
            {
                if (mob.GetComponent<Enemy>().CurrentHealth == 0)
                    deathSound.Play();
            }
        }
    }

    public void DieFireBall()
    {
        PlayDeathSound(fireballs, soundOfDieFireBall);
    }
    
    public void DieSlug()
    {
        PlayDeathSound(slugs, soundOfDieSlug);
    }
}
