using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameScript : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void Update()
    {

        

        if (Input.GetKey(KeyCode.Return))
        {
            StartGame();

        }
        

        
    }
}
