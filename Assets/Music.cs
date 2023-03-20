using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Music : MonoBehaviour
{
    public AudioSource MusicLoop;
    public AudioSource MusicNoLoop;
    bool looping = false;

    // Start is called before the first frame update
    void Start()
    {
        MusicNoLoop.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!looping && !MusicNoLoop.isPlaying) {
            looping = true;
            MusicLoop.Play();
        }

        if (looping && !MusicLoop.isPlaying) {
            MusicLoop.Play();
        }
    }
}
