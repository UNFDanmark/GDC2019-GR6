using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public bool HasGameStarted = false;
    public Text OptimoWinText;
    public Text PessimoWinText;
    public int mapSelected;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        int mapSelect = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>().mapSelect;
        if (Input.GetKey(KeyCode.Return))
        {
            Time.timeScale = 1;
            HasGameStarted = true;
        }
        if (Input.GetKey(KeyCode.Escape))
        {
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
