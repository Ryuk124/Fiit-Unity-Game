using UnityEngine;
using UnityEngine.SceneManagement;

public class DiePlatform : MonoBehaviour
{
    public GameObject Player;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player)
            SceneManager.LoadScene("NewStart");
    }
}
