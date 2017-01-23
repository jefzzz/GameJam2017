using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Text levelText;
    public int level = 0;
    public Spawner spawner;
    public float timer = 60;
    public Text timerText;
    public Text announceText;
    public PlayerMovement player;
    public bool isPause = false;
    public GameObject startOverUI;
    public int lives = 1;
    public Text livesUI;
    

	// Use this for initialization
	void Start () {
        lives = 100;
        announceLevel();
        spawner = FindObjectOfType<Spawner>();
        player = FindObjectOfType<PlayerMovement>();
	}

    void Update()
    {
        if (player.transform.position.y < -1)
        {
            gameOver();
            return;
        }
        if (isPause)
        {
            return;
        }
        
        if(timer <= 0)
        {
            announceLevel();
            timer = 60f;
        }
        else
        {
            timer -= Time.deltaTime;
        }
        timerText.text = "Timer " + timer.ToString("F2");
        
    }

    public void announceLevel()
    {
        StartCoroutine(announceLevelHelper());
    }

    IEnumerator announceLevelHelper()
    {
        isPause = true;
        announceText.gameObject.SetActive(true);
        announceText.text = "Get Ready!";
        yield return new WaitForSeconds(1f);
        announceText.text = "3";
        yield return new WaitForSeconds(0.8f);
        announceText.text = "2";
        yield return new WaitForSeconds(0.8f);
        announceText.text = "1";
        yield return new WaitForSeconds(0.8f);
        announceText.text = "Start";
        yield return new WaitForSeconds(0.8f);
        announceText.gameObject.SetActive(false);
        isPause = false;
        changeLevel();
    }

    public void changeLevel()
    {
        level++;
        levelText.text = "Wave: " + level;
        blinkText(levelText);
        clearMobs();
        spawner.spawnMassEnemies(2 * level - 1);    
    }

    public void blinkText(Text text)
    {
        StartCoroutine(blink(text));
    }

    IEnumerator blink(Text text)
    {
        text.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        text.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
    }

    public void clearMobs()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach(GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }

    public void gameOver()
    {
        announceText.text = "GAME OVER";
        announceText.gameObject.SetActive(true);
        startOverUI.SetActive(true);
        isPause = true;
    }

    public void startOver()
    {
        //return to title screen
    }

    public void loseLife()
    {
        lives--;
        livesUI.text = "Health: " +lives;
        if (lives == 0)
        {
            gameOver();
        } 
    }
	
	
}
