using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTriggerScript : MonoBehaviour
{
  
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player2")
        {
            SceneManager.LoadScene("OptimoWinScene");
        }
        if (other.tag == "Player1")
        {
            SceneManager.LoadScene("PessimoWinScene");
        }
    }
}