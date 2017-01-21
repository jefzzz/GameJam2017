using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stomach : MonoBehaviour {

    public Text points;
    private int count = 0; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "food")
        {
            count++;
            points.text = "Points: " + count;
        }
        Destroy(other);
    }
}
