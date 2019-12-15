using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAddPageAnimation : MonoBehaviour {
    public GameObject GameEndObject;
    public GameObject AddObject;
    public GameObject Score;

    void Start()
    {
        AddObject.SetActive(true);
    }

    void onAnimationEnd()
    {
        //GameEndObject.SetActive(true);
        AddObject.SetActive(false);
        gameObject.GetComponent<Animator>().Stop();
        Score.GetComponent<score>().resumable = false;
        GameObject.Destroy(this.gameObject);
        

    }
}
