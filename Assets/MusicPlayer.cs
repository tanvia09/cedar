using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource TitleSong;

    // Start is called before the first frame update
    void Start()
    {
        TitleSong = GetComponent<AudioSource>();
        TitleSong.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
