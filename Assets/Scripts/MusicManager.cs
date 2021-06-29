using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] musicList;
    private AudioSource musicPlayer;
    int clipIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        musicPlayer = GetComponent<AudioSource>();
        musicPlayer.clip = musicList[clipIndex];
        musicPlayer.Play();
        musicPlayer.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!musicPlayer.isPlaying)
        {
            musicPlayer.clip = GetNextClip();
            Debug.Log("now playing " + musicPlayer.clip.name);
            musicPlayer.Play();
        }
    }

   private AudioClip GetNextClip()
    {
        
        clipIndex++;
        if (clipIndex == musicList.Length) clipIndex = 0;
        musicPlayer.clip = musicList[clipIndex];

        return musicPlayer.clip;
    }
}
