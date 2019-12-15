using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catcherMove : MonoBehaviour {

	public float xSpeed ;
    public GameObject score;
	bool slide = false;

	float x;
	float y;
	float z;

	void Start () 
	{
        x = transform.position.x;
        y = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () 
	{
        if(!score.GetComponent<score>().dead)
        {
            if (Input.GetMouseButton(0))
            {
                if (slide == true)
                {
                    x += (Input.GetAxis("Mouse X")) * xSpeed * 0.02f;
                    if (x < -2.5f)
                        x = -2.5f;
                    if (x > 2.5f)
                        x = 2.5f;
                    transform.position = new Vector2(x, y);
                }
                slide = true;
            }
            else
            {
                slide = false;
            }
                
        }
        

	}
}
