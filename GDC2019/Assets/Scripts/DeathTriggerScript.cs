using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTriggerScript : MonoBehaviour
{
  
    public GameObject ScoreObject;

    void Start()
    {
        ScoreObject = GameObject.FindWithTag("ScoreManager");
    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player2")
        {
            print("Collide!");
            if (ScoreObject.GetComponent<ScoreManagerScript>().PessimoScore < 3 && ScoreObject.GetComponent<ScoreManagerScript>().OptimoScore < 3)
            {
                ScoreObject.GetComponent<ScoreManagerScript>().OptimoScore = ScoreObject.GetComponent<ScoreManagerScript>().OptimoScore++;
                SceneManager.LoadScene("GameScene");
            }
        }
        if (other.tag == "Player1")
        {
            if (ScoreObject.GetComponent<ScoreManagerScript>().PessimoScore < 3 && ScoreObject.GetComponent<ScoreManagerScript>().OptimoScore < 3)
            {
            ScoreObject.GetComponent<ScoreManagerScript>().PessimoScore = ScoreObject.GetComponent<ScoreManagerScript>().PessimoScore++;
            SceneManager.LoadScene("GameScene");
            }

        }
    }
}