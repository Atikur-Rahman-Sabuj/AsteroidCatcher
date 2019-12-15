using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkFallen : MonoBehaviour {
	public GameObject score;
	public GameObject objectAfterDestroy;

	

	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.y < -5)
		{
			score.GetComponent<score>().runnigLife++;
            score.GetComponent<score>().Streake = 0;
			//Debug.Log(score.GetComponent<score>().runnigLife);   
			GameObject.Destroy(gameObject);           
		}

		if (score.GetComponent<score>().dead)
		{
			Transform t = gameObject.transform;
			GameObject.Destroy(gameObject);
			Instantiate(objectAfterDestroy, t.position, Quaternion.identity);
		}
		if (score.GetComponent<score>().life <= score.GetComponent<score>().runnigLife)
		{
			Debug.Log("you are done");
			score.GetComponent<score>().dead = true; 
		}
	}
}
