using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] public float Hp = 3;
    public string LoadScene;

    public void TakeDamage(float damage)
    {
        Hp -= damage;
        if (Hp <= 0f)
        {
            Die();
            DeathCount.Enemies = 0;
        }
    }

    private void Die()
    {
        SceneManager.LoadScene(LoadScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
