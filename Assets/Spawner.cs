using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public int size;
    public GameObject[] food;

    private float timer = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(timer <= 0)
        {
            spawnFood();
            timer = 2f;
        }
        else
        {
            timer -= Time.deltaTime;
        }
        
	}

    void spawnFood()
    {
        float posX = Random.Range(-size, size);
        float posZ = Random.Range(-size, size);
        float index = Random.Range(0, food.Length - 1);
        GameObject go = (GameObject)Instantiate(food[(int)index], new Vector3(posX, 1.4f, posZ), Quaternion.identity);
    }

}