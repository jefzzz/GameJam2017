using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stomach : MonoBehaviour {

    public Text points;
    public Text scoreText;
    public int count = 0;

    public int score = 0;
    private Shooter shooter;
	// Use this for initialization
	void Start () {
        shooter = FindObjectOfType<Shooter>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "food" && !shooter.isOpen)
        {
            count++;
            score++;
            scoreText.text = "Score: " + score;
            
            if(count < 5)
            {
                points.text = "Power: " + count + "/5";
            } else
            {
                points.text = "POWER READY - press X";
            }
            
            Destroy(other.gameObject);
        }
    }
}
