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
    private GameManager manager;

    private float[] table1 = new float[4] { 2.9f, -1.6f, -4.3f, -2.1f};
    private float[] table2 = new float[4] { -0.1f, -1.6f, -2.1f, 3.1f};
    private float[] table3 = new float[4] { 9.5f, -1.6f, 3.1f, 4.8f};

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerMovement>();
        manager = FindObjectOfType<GameManager>();
        manager.spawner = this;
    }

    // Update is called once per frame
    void Update () {
        if(manager.isPause)
        {
            return;
        }
        if(this.transform.position.y < -10)
        {
            Destroy(this.gameObject);
        }
		if(foodTiemr <= 0)
        {
            spawn(food);
            //spawnFood();
            foodTiemr = 10f;
        }
        else
        {
            foodTiemr -= Time.deltaTime;
        }
        if (enemyTimer <= 0)
        {
            spawn(enemies);
            enemyTimer = 1f;
        }
        else
        {
            enemyTimer -= Time.deltaTime;
        }

    }

    public void spawnMassFood(int quantity)
    {
        for(int i = 0; i< quantity; i++)
        {
            spawnFood();
        }
    }

    public void spawnMassEnemies (int quantity)
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

    void spawn(GameObject[] array)
    {
        int randomTable = (int) Random.Range(0f, 3f);
        float[] chosenTable;
        if(randomTable == 0)
        {
            chosenTable = table1;
        } else if (randomTable == 1)
        {
            chosenTable = table2;
        } else
        {
            chosenTable = table3;
        }
        float posX = Random.Range(chosenTable[0], chosenTable[1]);
        float posZ = Random.Range(chosenTable[2], chosenTable[3]);
        float index = Random.Range(0, food.Length);
        GameObject go = (GameObject)Instantiate(array[(int)index], new Vector3(posX, 0.2f, posZ), Quaternion.identity);
    }

}