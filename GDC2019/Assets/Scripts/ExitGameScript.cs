﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGameScript : MonoBehaviour
{
    public int mapSelect;
    public GameObject pessimoWinImage;
    public GameObject optimoWinImage;


    public void ExitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
       
        //GameObject.Find("PessimoWinImage").SetActive(false);
        //GameObject.Find("OptimoWinImage").SetActive(false);
        SceneManager.LoadScene("MenuScene");
        print("menu");
        
    }

    public void Resume()
    {
        print("resume");
        mapSelect = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>().mapSelect;
        if (mapSelect == 0)
        {
            SceneManager.LoadScene("GameScene");
            GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>().OnSceneChange("GameScene");
        }
        if (mapSelect == 1)
        {
            SceneManager.LoadScene("LargeGameScene");
            GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>().OnSceneChange("LargeGameScene");
        }
        if (mapSelect == 2)
        {
            SceneManager.LoadScene("ObstacleGameScene");
            GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>().OnSceneChange("ObstacleGameScene");
        }
    }
}
