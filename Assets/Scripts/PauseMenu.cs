using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PM;
    public Button ResumeButton;
    public Button MainMenuButton;
    private bool _isPaused;

    // Start is called before the first frame update
    void Start()
    {
        PM.SetActive(false);
        MainMenuButton.onClick.AddListener(LoadMainMenu);
        ResumeButton.onClick.AddListener(ResumeGame);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(_isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        PM.SetActive(true);
        Time.timeScale = 0f;
        _isPaused = true;
    }

    public void ResumeGame()
    {
        PM.SetActive(false);
        Time.timeScale = 1f;
        _isPaused = false;
    }
    
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
