using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public int size;
    public GameObject[] food;
    public GameObject[] enemies;

    private float foodTiemr = 0;
    private float enemyTimer = 0;
    private PlayerMovement player;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerMovement>();
        spawnMassFood(200);
    }

    // Update is called once per frame
    void Update () {
		if(foodTiemr <= 0)
        {
            spawnFood();
            foodTiemr = 1f;
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

    void spawnMassFood(int quantity)
    {
        for(int i = 0; i< quantity; i++)
        {
            spawnFood();
        }
    }

    void spawnMassEnemies (int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            spawnEnemy();
        }
    }

    void spawnFood()
    {
        float posX = Random.Range(player.transform.position.x - 5f, player.transform.position.x + 5f);
        float posZ = Random.Range(player.transform.position.z - 5f, player.transform.position.z + 5f);
        float index = Random.Range(0, food.Length);
        GameObject go = (GameObject)Instantiate(food[(int)index], new Vector3(posX, 0f, posZ), Quaternion.identity);
    }

    void spawnEnemy()
    {
        float posX = Random.Range(player.transform.position.x - 10f, player.transform.position.x + 10f);
        float posZ = Random.Range(player.transform.position.z - 10f, player.transform.position.z + 10f);
        float index = Random.Range(0, enemies.Length);
        GameObject go = (GameObject)Instantiate(enemies[(int)index], new Vector3(posX, 0f, posZ), Quaternion.identity);
    }

}