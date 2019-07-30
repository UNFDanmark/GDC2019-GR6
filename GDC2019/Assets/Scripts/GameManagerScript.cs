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
    public Text OptimoScoreText;
    public Text PessimoScoreText;
    public int mapSelected;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        Text[] textArray = canvas.GetComponentsInChildren<Text>();
        foreach (Text scoreText in textArray)
        {
            if (scoreText.name == "PessimoScoreText")
            {
                PessimoScoreText = scoreText;
            }
            else if (scoreText.name == "OptimoScoreText")
            {
                OptimoScoreText = scoreText;
            }
            else if (scoreText.name == "PessimoWinText")
            {
                PessimoWinText = scoreText;
            }
            else if (scoreText.name == "OptimoWinText")
            {
                OptimoWinText = scoreText;
            }

        }
        OptimoScoreText.enabled = true;
        PessimoScoreText.enabled = true;
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
