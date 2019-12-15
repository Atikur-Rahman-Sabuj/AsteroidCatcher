using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class mainMenu : MonoBehaviour {

	public TextMeshProUGUI highScoreText;
    public GameObject SoundButton;
    public GameObject MuteButton;

	void Start()
	{
		highScoreText.SetText(PlayerPrefs.GetInt("HighScore",0).ToString());
        if(PlayerPrefs.GetInt("Sound", 1) == 1)
        {
            PlayerPrefs.SetInt("Sound", 1);
            SoundButton.SetActive(true);
            MuteButton.SetActive(false);
        }
        else
        {
            PlayerPrefs.SetInt("Sound", 0);
            SoundButton.SetActive(false);
            MuteButton.SetActive(true);
        }
	}

	public void resetHighScore()
	{
		PlayerPrefs.SetInt("HighScore", 0);
		highScoreText.SetText("0");
	}

	public void startGame(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
    public void Sound()
    {
        PlayerPrefs.SetInt("Sound", 1);
    }
    public void Mute()
    {
        PlayerPrefs.SetInt("Sound", 0);
    }

}
