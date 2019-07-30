using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGameScript1 : MonoBehaviour
{
    public int mapSelect;
    public GameObject pessimoWinImage;
    public GameObject optimoWinImage;
    public Vector3 startUIPosition;
    public GameObject ScoreManager;

    public void Start()
    {
        startUIPosition = optimoWinImage.GetComponent<RectTransform>().position;
    }
    public void OptimoYeet()
    {
        optimoWinImage.GetComponent<RectTransform>().position = new Vector3(9000, 0);
        print("yeet o");
    }
    public void OptimoUnYeet()
    {
        print("un yeet o");
        optimoWinImage.GetComponent<RectTransform>().position = startUIPosition;//optimoWinImage.GetComponent<RectTransform>().sizeDelta / 2f;
    }
    public void PessimoYeet()
    {
        pessimoWinImage.GetComponent<RectTransform>().position = new Vector3(9000, 0);
        print("yeet p");
    }
    public void PessimoUnYeet()
    {
        print("un yeet o");
        pessimoWinImage.GetComponent<RectTransform>().position = startUIPosition;//optimoWinImage.GetComponent<RectTransform>().sizeDelta / 2f;
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        GetComponent<RectTransform>().position = new Vector3(9000, 0, 0);
        //GameObject.Find("PessimoWinImage").SetActive(false);
        //GameObject.Find("OptimoWinImage").SetActive(false);
        SceneManager.LoadScene("MenuScene");
        print("menu");
        
    }

    public void Resume()
    {
        print("resume");
        OptimoYeet();
        PessimoYeet();
        
        mapSelect = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>().mapSelect;
        print("map" + mapSelect);
        ScoreManager.GetComponent<ScoreManagerScript>().OptimoScore = 0;
        ScoreManager.GetComponent<ScoreManagerScript>().PessimoScore = 0;
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
