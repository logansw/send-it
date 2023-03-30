using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // TODO: Change these method names to corresponding gym names
    public void LoadGym1()
    {
        SceneManager.LoadScene("Main");
    }

    public void LoadGym2()
    {
        SceneManager.LoadScene("Gym2");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
