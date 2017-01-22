using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public int size;
    public GameObject[] food;
    public GameObject[] enemies;

    private float foodTiemr = 0;
    private float enemyTimer = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(foodTiemr <= 0)
        {
            spawnFood();
            foodTiemr = 10f;
        }
        else
        {
            foodTiemr -= Time.deltaTime;
        }
        if (enemyTimer <= 0)
        {
            spawnEnemy();
            enemyTimer = 10f;
        }
        else
        {
            enemyTimer -= Time.deltaTime;
        }

    }

    void spawnFood()
    {
        float posX = Random.Range(-size, size);
        float posZ = Random.Range(-size, size);
        float index = Random.Range(0, food.Length);
        GameObject go = (GameObject)Instantiate(food[(int)index], new Vector3(posX, 0f, posZ), Quaternion.identity);
    }

    void spawnEnemy()
    {
        float posX = Random.Range(-size, size);
        float posZ = Random.Range(-size, size);
        float index = Random.Range(0, enemies.Length);
        GameObject go = (GameObject)Instantiate(enemies[(int)index], new Vector3(posX, 0f, posZ), Quaternion.identity);
    }

}