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
        //If Player1 leaves a tile it has left before, Destroy gameobject
        if (collisionInfo.collider.tag == "Player2")
        {
            if (ScoreObject.GetComponent<ScoreManagerScript>().PessimoScore < 3 && ScoreObject.GetComponent<ScoreManagerScript>().OptimoScore < 3)
            {
                ScoreObject.GetComponent<ScoreManagerScript>().OptimoScore++;
                print(ScoreObject.GetComponent<ScoreManagerScript>().PessimoScore);
                SceneManager.LoadScene("GameScene");
                
            }
        }

        if (collisionInfo.collider.tag == "Player1")
        {
            if (ScoreObject.GetComponent<ScoreManagerScript>().PessimoScore < 3 && ScoreObject.GetComponent<ScoreManagerScript>().OptimoScore < 3)
            {
                ScoreObject.GetComponent<ScoreManagerScript>().PessimoScore++;
                //print(ScoreObject.GetComponent<ScoreManagerScript>().PessimoScore);
                SceneManager.LoadScene("GameScene");
            }
        }
    }
}
 