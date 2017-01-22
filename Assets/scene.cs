using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene : MonoBehaviour {

	public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    public void startOver()
    {
        SceneManager.LoadScene(0);
    }

}
