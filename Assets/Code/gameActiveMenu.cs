using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameActiveMenu : MonoBehaviour {

    public void Pause()
    {

        Time.timeScale = 0f;

    }

    public void Play()
    {

        Time.timeScale = 1.0f;

    }
    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
        Time.timeScale = 1.0f;
    }
    public void Back()
    {
        //SceneManager.LoadLevel(SceneManager.GetActiveScene().buildIndex-1);
        Application.LoadLevel(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
