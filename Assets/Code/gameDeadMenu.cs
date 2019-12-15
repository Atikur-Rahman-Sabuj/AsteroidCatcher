using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class gameDeadMenu : MonoBehaviour {
    public GameObject Score;
    public GameObject addAnimationObject;
    public GameObject InGameCanvus;
    public GameObject Capsule;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;


    public void restart()
    {
       // Application.LoadLevel(Application.loadedLevel);
        SceneManager.LoadScene(Application.loadedLevel);
    }
    public void back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void exit()
    {
        Application.Quit();
    }
    public void playAdd()
    {
        addAnimationObject.GetComponent<Animator>().StopPlayback();
        //GameObject.Destroy(addAnimationObject);
        if(Advertisement.IsReady())
        {
            Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = handleResult });
        }
        else
        {
            Debug.Log("Add wasn't ready");
            Score.GetComponent<score>().dead = true;
            Score.GetComponent<score>().resumable = false;
            addAnimationObject.SetActive(false);
        }
    }

    private void handleResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("Watched the video");
                Score.GetComponent<score>().dead = false;
                Score.GetComponent<score>().resumable = false;
                Score.GetComponent<score>().runnigLife = 7;
                //run to code to initialize stars
                addAnimationObject.SetActive(false);
                InGameCanvus.SetActive(true);
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(true);
                Capsule.transform.position = new Vector2(0, -3.5f);
                
                break;
            case ShowResult.Skipped:
                Debug.Log("Video skipped");
                Score.GetComponent<score>().dead = true;
                Score.GetComponent<score>().resumable = false;
                addAnimationObject.SetActive(false);
                break;
            case  ShowResult.Failed:
                Debug.Log("Add didnot played");
                Score.GetComponent<score>().dead = true;
                Score.GetComponent<score>().resumable = false;
                addAnimationObject.SetActive(false);
                break;
        }
    }
}
