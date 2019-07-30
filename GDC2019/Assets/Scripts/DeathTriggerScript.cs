using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTriggerScript : MonoBehaviour
{
    public int mapSelected;
    public GameObject ScoreObject;

    void Start()
    {
        ScoreObject = GameObject.FindWithTag("ScoreManager");
    }
    
    void OnTriggerEnter(Collider other)
    {
        int mapSelected = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>().mapSelect;
        
            if (other.tag == "Player2")
            {
                print("Collide!");
                if (ScoreObject.GetComponent<ScoreManagerScript>().PessimoScore < 3 && ScoreObject.GetComponent<ScoreManagerScript>().OptimoScore < 3)
                {
                    ScoreObject.GetComponent<ScoreManagerScript>().OptimoScore++;
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
            }
            if (other.tag == "Player1")
            {
                if (ScoreObject.GetComponent<ScoreManagerScript>().PessimoScore < 3 && ScoreObject.GetComponent<ScoreManagerScript>().OptimoScore < 3)
                {
                    ScoreObject.GetComponent<ScoreManagerScript>().PessimoScore++;
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

            }
        
        
    }

}