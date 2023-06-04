using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GoToMenu : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    private void Awake()
    {
        videoPlayer.loopPointReached += EndReached;
    }

    private void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("Menu");
    }
}
