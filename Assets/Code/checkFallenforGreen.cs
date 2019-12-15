using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkFallenforGreen : MonoBehaviour {

    public GameObject score;
    public GameObject objectAfterDestroy;



    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -5)
        {
            //Do nothing
        }

        if (score.GetComponent<score>().dead)
        {
            Transform t = gameObject.transform;
            GameObject.Destroy(gameObject);
            Instantiate(objectAfterDestroy, t.position, Quaternion.identity);
        }
    }
}
