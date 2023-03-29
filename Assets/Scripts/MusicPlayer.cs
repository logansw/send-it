using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{

    public AudioSource MusicLoop;
    public AudioSource MusicNoLoop;
    bool looping = false;

    void Awake() 
    {
        // Initialize music game objects and allow loading into new scenes
        initializeMusicObjects();
        // Set audio volume to max if not previously set, otherwise set volume to previous value on slider.
        initializeMusicVolume();
    }

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

    private void initializeMusicObjects()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if (objs.Length > 1) {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void initializeMusicVolume()
    {
        if (!PlayerPrefs.HasKey("musicVolume")) {
            PlayerPrefs.SetFloat("musicVolume", 1);
        }
        AudioListener.volume = PlayerPrefs.GetFloat("musicVolume");
    }
}
