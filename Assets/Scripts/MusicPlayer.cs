using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{

    public AudioSource MusicLoop;
    public AudioSource MusicNoLoop;
    private bool _looping = false;
    private static MusicPlayer instance = null;

    void Awake() 
    {
        // Initialize music game objects and allow loading into new scenes
        InitializeMusicObjects();
        // Set audio volume to max if not previously set, otherwise set volume to previous value on slider.
        InitializeMusicVolume();
    }

    void Update()
    {
        if (!_looping && !MusicNoLoop.isPlaying) {
            _looping = true;
            MusicLoop.Play();
        }

        if (_looping && !MusicLoop.isPlaying) {
            MusicLoop.Play();
        }
    }

    private void InitializeMusicObjects()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            return;
        }
        Destroy(this.gameObject);
    }

    private void InitializeMusicVolume()
    {
        if (!PlayerPrefs.HasKey("musicVolume")) {
            PlayerPrefs.SetFloat("musicVolume", 1);
        }
        AudioListener.volume = PlayerPrefs.GetFloat("musicVolume");
    }
}
