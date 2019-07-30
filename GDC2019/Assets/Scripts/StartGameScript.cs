using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class StartGameScript : MonoBehaviour
{
    public int mapSelected;
    public AudioClip audioPause;
    public AudioClip audioScreen;
   

    public void StartGame()
    {
        int mapSelected = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>().mapSelect;
        if (mapSelected == 0)
        {
            SceneManager.LoadScene("GameScene");
            GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>().OnSceneChange("GameScene");
        }
        if (mapSelected == 1)
        {
            SceneManager.LoadScene("LargeGameScene");
            GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>().OnSceneChange("LargeGameScene");
        }
        if (mapSelected == 2)
        {
            SceneManager.LoadScene("ObstacleGameScene");
            GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>().OnSceneChange("ObstacleGameScene");
        }
        //audioPause.Stop();
        //audioScreen.Play();
        
    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartGame();

        }
        

        
    }
}
