using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class destroyOnCollide : MonoBehaviour {
    public GameObject objectAfterDestroy;
    public GameObject greenObjectAfterDestroy;
    public GameObject redObjectAfterDestroy;
    public GameObject heartAnimObject;
    public GameObject skullAnimObject;
    public GameObject highScoreBanner;
    public GameObject score;
    public int catched = 0;
    public TextMeshProUGUI scoreShow;
    public TextMeshProUGUI finalScoreShow;

    public GameObject NumberScoreStreak;
    public TextMeshProUGUI NumberScoreStreakText;

    public AudioSource dropSound;
    public AudioClip drop1;
    public AudioClip drop2;
    public AudioClip drop3;

    public int highScore = 0;
    string highScoreKey = "HighScore";


    void Start () {
        Time.timeScale = 1;
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        GetComponent<Renderer>().materials[0].EnableKeyword("_EMISSION");
        dropSound = GetComponent<AudioSource>();
        NumberScoreStreak.SetActive(false);
    }

    IEnumerator waitt()
    {
     
        yield return new WaitForSeconds(.05f);
        //GetComponent<Renderer>().materials[0].color = Color.black;
        GetComponent<Renderer>().materials[0].SetColor("_EmissionColor", Color.black);
    
    }
    
    // Update is called once per frame
    void Update () {

        score.GetComponent<score>().PlayerScore = catched;
        if (score.GetComponent<score>().dead)
        {
            //This is where the game ends
            if (catched > highScore)
            {
                PlayerPrefs.SetInt(highScoreKey, catched);
                PlayerPrefs.Save();
                highScoreBanner.SetActive(true);
            }
        }		
    }
    void OnTriggerEnter(Collider other)
    {
        dropSound.Play();
        if(other.gameObject.name=="Sphere(Clone)")
        {
            //Increase Score
            if (PlayerPrefs.GetInt("Sound", 0).Equals(1))
            {
                dropSound.PlayOneShot(drop1);
            }
            IncreaseScore(score.GetComponent<score>().Streake);
            scoreShow.text = catched.ToString();
            finalScoreShow.text = catched.ToString();
            Transform t = other.gameObject.transform;
            Destroy(other.gameObject);
            Instantiate(objectAfterDestroy, t.position, Quaternion.identity);
            //GetComponent<Renderer>().materials[0].color= Color.white;

            GetComponent<Renderer>().materials[0].SetColor("_EmissionColor", Color.white);
            StartCoroutine(waitt());
            waitt();
        }
        else if (other.gameObject.name == "GreenSphere(Clone)")
        {
            if (PlayerPrefs.GetInt("Sound", 0).Equals(1))
            {
                dropSound.PlayOneShot(drop2);
            }
            //Increase Life
            if (score.GetComponent<score>().runnigLife>0)
            {
                score.GetComponent<score>().runnigLife--;
            }   
            Transform t = other.gameObject.transform;
            Destroy(other.gameObject);
            Instantiate(greenObjectAfterDestroy, t.position, Quaternion.identity);
            Instantiate(heartAnimObject, t.position, Quaternion.identity);
            //GetComponent<Renderer>().materials[0].color= Color.white;

            GetComponent<Renderer>().materials[0].SetColor("_EmissionColor", Color.white);
            StartCoroutine(waitt());
            waitt();
        }
        else
        {
            score.GetComponent<score>().Streake = 0;
            if(PlayerPrefs.GetInt("Sound", 0).Equals(1))
            {
                dropSound.PlayOneShot(drop3);
            }
            score.GetComponent<score>().runnigLife = score.GetComponent<score>().runnigLife + 2;
            Transform t = other.gameObject.transform;
            Destroy(other.gameObject);
            Instantiate(redObjectAfterDestroy, t.position, Quaternion.identity);
            Instantiate(skullAnimObject, t.position, Quaternion.identity);
            //GetComponent<Renderer>().materials[0].color= Color.white;
            GetComponent<Renderer>().materials[0].SetColor("_EmissionColor", Color.white);
            StartCoroutine(waitt());
            waitt();
        }
        
    }

    private void IncreaseScore(int streak)
    {
        if(streak<5)
        {
            catched++;
            score.GetComponent<score>().Streake++;
        }
        else if(streak<10)
        {
            if (streak == 5)
            {
                NumberScoreStreakText.text = "+2";
                NumberScoreStreak.SetActive(true);
            }
            catched = catched + 2;
            score.GetComponent<score>().Streake++;
            
        }
        else if (streak < 15)
        {
            if (streak == 10)
            {
                NumberScoreStreakText.text = "+3";
                NumberScoreStreak.SetActive(true);
            }
            catched = catched + 3;
            score.GetComponent<score>().Streake++;
            NumberScoreStreakText.text = "+3";
        }
        else if (streak < 20)
        {
            if (streak == 15)
            {
                NumberScoreStreakText.text = "+4";
                NumberScoreStreak.SetActive(true);
            }
            catched = catched + 4;
            score.GetComponent<score>().Streake++;
            NumberScoreStreakText.text = "+4";
        }
        else if (streak < 25)
        {
            if (streak == 20)
            {
                NumberScoreStreakText.text = "+5";
                NumberScoreStreak.SetActive(true);
            }
            catched = catched + 5;
            score.GetComponent<score>().Streake++;
            NumberScoreStreakText.text = "+5";
        }
    } 
    
}
