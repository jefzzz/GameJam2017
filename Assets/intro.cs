using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intro : MonoBehaviour {
    public GameObject food;
    public Vector3 location = new Vector3(-1, 20, 2);
    public int size = 20;
    // Use this for initialization
    void Start () {
		for(int i = 0; i < size; i++)
        {
            if (i == size -1)
            {
                GameObject go = (GameObject)Instantiate(food, location + new Vector3(0, i * 2 + 10, -1), Quaternion.identity);
                go.transform.localScale = new Vector3(5, 5, 5);

            } else
            {
                GameObject go = (GameObject)Instantiate(food, location + new Vector3(0, i * 2, 0), Quaternion.identity);

            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
