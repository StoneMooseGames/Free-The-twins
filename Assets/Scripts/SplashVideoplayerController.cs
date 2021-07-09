using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class SplashVideoplayerController : MonoBehaviour
{
    VideoPlayer videoPlayer; 
    
    void Start()
    {
        videoPlayer = this.gameObject.GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += LoadScene;
    }
    void LoadScene(VideoPlayer vp)
    {
        SceneManager.LoadScene("StartUI");
    }
}
