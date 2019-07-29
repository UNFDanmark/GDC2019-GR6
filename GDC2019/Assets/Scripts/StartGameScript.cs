using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameScript : MonoBehaviour
{
    public int mapSelected;
    public void StartGame()
    {
        int mapSelected = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>().mapSelect;
        if (mapSelected == 0)
        {
            SceneManager.LoadScene("GameScene");
        }
        if (mapSelected == 1)
        {
            SceneManager.LoadScene("LargeGameScene");
        }
        if (mapSelected == 2)
        {
            SceneManager.LoadScene("ObstacleGameScene");
        }
    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            StartGame();

        }
        

        
    }
}
