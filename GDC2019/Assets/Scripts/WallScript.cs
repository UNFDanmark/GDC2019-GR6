using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallScript : MonoBehaviour
{
    public GameObject ScoreObject;
    

    void Start()
    {
        ScoreObject = GameObject.FindWithTag("ScoreManager");
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        int mapSelected = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>().mapSelect;
        if (collisionInfo.collider.tag == "Player2")
        {
            if (ScoreObject.GetComponent<ScoreManagerScript>().PessimoScore < 3 && ScoreObject.GetComponent<ScoreManagerScript>().OptimoScore < 3)
            {
                ScoreObject.GetComponent<ScoreManagerScript>().OptimoScore++;
                print(ScoreObject.GetComponent<ScoreManagerScript>().PessimoScore);
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

        if (collisionInfo.collider.tag == "Player1")
        {
            if (ScoreObject.GetComponent<ScoreManagerScript>().PessimoScore < 3 && ScoreObject.GetComponent<ScoreManagerScript>().OptimoScore < 3)
            {
                ScoreObject.GetComponent<ScoreManagerScript>().PessimoScore++;
                //print(ScoreObject.GetComponent<ScoreManagerScript>().PessimoScore);
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
 