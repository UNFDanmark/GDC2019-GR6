using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTriggerScript : MonoBehaviour
{
  
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Player2")
        {
            SceneManager.LoadScene("OptimoWinScene");
        }
        if (collisionInfo.collider.tag == "Player1")
        {
            SceneManager.LoadScene("PessimoWinScene");
        }
    }
}