using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class creatAsteroid : MonoBehaviour {
    public GameObject checkDead;
    public GameObject shield;
    public GameObject inGameCanvas;
    public GameObject afterGameCanvas;
    public GameObject addCanvas;
    public GameObject addAnimationObject;
    public TextMeshProUGUI addCanvasScore;
    //public TextMeshProUGUI showLiftText;


    //This are the stars to show life
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject star4;
    public GameObject star5;
    public GameObject star6;
    public GameObject star7;
    public GameObject star8;
    public GameObject star9;
    public GameObject star10;

    
    public Transform asteroid;
    public Transform greenAsteroid;
    public Transform redAsteroid;
    float timer = 0;
    float timerGreen = 0;
    float timerRed = 0;
    float limit = 2f;
    float limitGreen = 8f;
    float limitRed = 15f;
    // Use this for initialization
    void Start () {
        //Scoring and player life initiating here
        checkDead.GetComponent<score>().PlayerScore = 0;
        checkDead.GetComponent<score>().life = 10;
        checkDead.GetComponent<score>().runnigLife = 0;
        checkDead.GetComponent<score>().dead = false;
        checkDead.GetComponent<score>().resumable = true;
        checkDead.GetComponent<score>().Streake = 0;
        timer = 0;
        timerGreen = 0;
        timerRed = 0;
        limit = 2f;
        limitGreen = 8f;
        limitRed = 15f;
    }
    // Update is called once per frame
    void Update () {
        showStar(checkDead.GetComponent<score>().life - checkDead.GetComponent<score>().runnigLife);
        //showLiftText.SetText((checkDead.GetComponent<score>().life-checkDead.GetComponent<score>().runnigLife).ToString());
        timer += Time.deltaTime;
        timerGreen += Time.deltaTime;
        timerRed += Time.deltaTime;
        if (!checkDead.GetComponent<score>().dead)
        {
            //For normal White asteroid
            if (timer > limit)
            {
                Instantiate(asteroid, new Vector2(Random.Range(-2.5f, 2.5f), 5), Quaternion.identity);
                if (limit > .25f)
                {
                    limit -= .05f;
                }
                timer = 0;
            }
            //For Green asteroid
            if (timerGreen > limitGreen)
            {
                Instantiate(greenAsteroid, new Vector2(Random.Range(-2.5f, 2.5f), 5), Quaternion.identity);
                if (true)
                {
                    limitGreen += .5f;
                }
                timerGreen = 0;
            }
            //For Red asteroid
            if (timerRed > limitRed)
            {
                Instantiate(redAsteroid, new Vector2(Random.Range(-2.5f, 2.5f), 5), Quaternion.identity);
                if (limitRed > .25f)
                {
                    limitRed -= .05f;
                }
                timerRed = 0;
            }

        }
        else if (checkDead.GetComponent<score>().dead && checkDead.GetComponent<score>().resumable)
        {
            //Debug.Log("Getting it");
            //when the game ends
            //afterGameCanvas.SetActive(true);
            addAnimationObject.SetActive(true);          
            inGameCanvas.SetActive(false);
            shield.transform.position = new Vector2(0, -20f);
            addCanvasScore.text = checkDead.GetComponent<score>().PlayerScore.ToString();
            timer = 0;
            timerGreen = 0;
            timerRed = 0;
            limit = .5f;
            limitGreen = 8f;
            limitRed = 10f;
            
        }
        else
        {
            //When the game ends and not resumable any  more
            afterGameCanvas.SetActive(true);
            inGameCanvas.SetActive(false);
            //shield.transform.position = new Vector3(0, -20, 0);
        }
        
    }
    private void showStar(int lifes)
    {
        switch (lifes)
        {
            case 0:
                star1.SetActive(false);
                star2.SetActive(false);
                break;
            case 1:
                star1.SetActive(true);
                star2.SetActive(false);
                star3.SetActive(false);
                break;
            case 2:
                star2.SetActive(true);
                star3.SetActive(false);
                star4.SetActive(false);
                break;
            case 3:
                star3.SetActive(true);
                star4.SetActive(false);
                star5.SetActive(false);
                break;
            case 4:
                star4.SetActive(true);
                star5.SetActive(false);
                star6.SetActive(false);
                break;
            case 5:
                star5.SetActive(true);
                star6.SetActive(false);
                star7.SetActive(false);
                break;
            case 6:
                star6.SetActive(true);
                star7.SetActive(false);
                star8.SetActive(false);
                break;
            case 7:
                star7.SetActive(true);
                star8.SetActive(false);
                star9.SetActive(false);
                break;
            case 8:
                star8.SetActive(true);
                star9.SetActive(false);
                star10.SetActive(false);
                break;
            case 9:
                star9.SetActive(true);
                star10.SetActive(false);
                break;
            case 10:
                star10.SetActive(true);
                break;

        }
    }
}
