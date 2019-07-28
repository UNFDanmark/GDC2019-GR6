using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallScript : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collisionInfo)
    {
        //If Player1 leaves a tile it has left before, Destroy gameobject
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