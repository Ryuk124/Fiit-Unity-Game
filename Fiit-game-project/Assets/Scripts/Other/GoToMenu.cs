using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GoToMenu : MonoBehaviour
{
    public VideoPlayer player;
    void Update()
    {
        if (!player.isPlaying)
            SceneManager.LoadScene("Menu");
    }
}
