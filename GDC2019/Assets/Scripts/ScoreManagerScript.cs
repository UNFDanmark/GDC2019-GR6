using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManagerScript : MonoBehaviour
{
    public int OptimoScore;
    public int PessimoScore;

    Text OptimoScoreText;
    Text PessimoScoreText;

    Text OptimoWinText;
    Text PessimoWinText;

    public GameObject canvas;

    public int delay = 5;
    public int roundsSelected = -1;
    public int mapSelect = -1;

    int currentScene;



    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        GameObject[] ScoreManagers = GameObject.FindGameObjectsWithTag("ScoreManager");
        int scoreManagerNo = ScoreManagers.Length;
        if (scoreManagerNo > 1)
        {
            if (ScoreManagers[0].GetComponent<ScoreManagerScript>().OptimoScore + ScoreManagers[0].GetComponent<ScoreManagerScript>().PessimoScore < ScoreManagers[1].GetComponent<ScoreManagerScript>().OptimoScore + ScoreManagers[1].GetComponent<ScoreManagerScript>().PessimoScore)
            {
                Destroy(ScoreManagers[0]);

            }

            else
            {
                Destroy(ScoreManagers[1]);
            }
       }

        canvas = GameObject.FindGameObjectWithTag("Canvas");
        Text[] textArray= canvas.GetComponentsInChildren<Text>();
        foreach (Text scoreText in textArray)
        {
            if(scoreText.name == "PessimoScoreText")
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
    }

    // Update is called once per frame
    void Update()
    {
        OptimoScoreFunction();
        PessimoScoreFunction();
        currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene == 0)
        {
            mapSelect = GameObject.FindGameObjectWithTag("Map").GetComponent<MapSelectorScript>().mapSelected;
            roundsSelected = GameObject.FindGameObjectWithTag("Round").GetComponent<RoundsSelectedScript>().roundsSelected;
        }
    }

    public void OptimoScoreFunction()
    {
        if (OptimoScore == 0)
        {
            OptimoScoreText.text = "0 - Optimo";
        }

        if (OptimoScore == 1)
        {
            OptimoScoreText.text = "1 - Optimo";
        }

        if (OptimoScore == 2 && roundsSelected == 0)
        {
            OptimoScoreText.text = "2 - Optimo";
            OptimoWinText.enabled = true;
            if (Input.GetKey(KeyCode.Return))
            {
                OptimoScore = 0;
                PessimoScore = 0;
                if (mapSelect == 0)
                {
                    SceneManager.LoadScene("GameScene");
                }
                if (mapSelect == 1)
                {
                    SceneManager.LoadScene("LargeGameScene");
                }
                if (mapSelect == 2)
                {
                    SceneManager.LoadScene("ObstacleGameScene");
                }
                OptimoWinText.enabled = false;

            }
            if (OptimoScore == 3 && roundsSelected == 1)
            {
                OptimoScoreText.text = "3 - Optimo";
                OptimoWinText.enabled = true;
                float WinTime = Time.time;
                if (Time.time > WinTime + delay || Input.GetKey(KeyCode.Return))
                {
                    OptimoScore = 0;
                    PessimoScore = 0;
                    if (mapSelect == 0)
                    {
                        SceneManager.LoadScene("GameScene");
                    }
                    if (mapSelect == 1)
                    {
                        SceneManager.LoadScene("LargeGameScene");
                    }
                    if (mapSelect == 2)
                    {
                        SceneManager.LoadScene("ObstacleGameScene");
                    }
                    OptimoWinText.enabled = false;

                }

            }
            if (OptimoScore == 4 && roundsSelected == 2)
            {
                OptimoScoreText.text = "4 - Optimo";
                OptimoWinText.enabled = true;
                float WinTime = Time.time;
                if (Time.time > WinTime + delay || Input.GetKey(KeyCode.Return))
                {
                    OptimoScore = 0;
                    PessimoScore = 0;
                    if (mapSelect == 0)
                    {
                        SceneManager.LoadScene("GameScene");
                    }
                    if (mapSelect == 1)
                    {
                        SceneManager.LoadScene("LargeGameScene");
                    }
                    if (mapSelect == 2)
                    {
                        SceneManager.LoadScene("ObstacleGameScene");
                    }
                    OptimoWinText.enabled = false;

                }

            }
        }
    }
        public void PessimoScoreFunction()
        {

        if (PessimoScore == 0)
            {
                PessimoScoreText.text = "Pessimo - 0";
            }

            if (PessimoScore == 1)
            {
                PessimoScoreText.text = "Pessimo - 1";
            }

        if (PessimoScore == 2 && roundsSelected == 0)
        {
            PessimoScoreText.text = "2 - Optimo";
            PessimoWinText.enabled = true;
            if (Input.GetKey(KeyCode.Return))
            {
                OptimoScore = 0;
                PessimoScore = 0;
                if (mapSelect == 0)
                {
                    SceneManager.LoadScene("GameScene");
                }
                if (mapSelect == 1)
                {
                    SceneManager.LoadScene("LargeGameScene");
                }
                if (mapSelect == 2)
                {
                    SceneManager.LoadScene("ObstacleGameScene");
                }
                PessimoWinText.enabled = false;

            }
            if (PessimoScore == 3 && roundsSelected == 1)
            {
                PessimoScoreText.text = "3 - Optimo";
                PessimoWinText.enabled = true;
                float WinTime = Time.time;
                if (Time.time > WinTime + delay || Input.GetKey(KeyCode.Return))
                {
                    OptimoScore = 0;
                    PessimoScore = 0;
                    if (mapSelect == 0)
                    {
                        SceneManager.LoadScene("GameScene");
                    }
                    if (mapSelect == 1)
                    {
                        SceneManager.LoadScene("LargeGameScene");
                    }
                    if (mapSelect == 2)
                    {
                        SceneManager.LoadScene("ObstacleGameScene");
                    }
                    PessimoWinText.enabled = false;

                }

            }
            if (PessimoScore == 4 && roundsSelected == 2)
            {
                PessimoScoreText.text = "4 - Optimo";
                PessimoWinText.enabled = true;
                float WinTime = Time.time;
                if (Time.time > WinTime + delay || Input.GetKey(KeyCode.Return))
                {
                    OptimoScore = 0;
                    PessimoScore = 0;
                    if (mapSelect == 0)
                    {
                        SceneManager.LoadScene("GameScene");
                    }
                    if (mapSelect == 1)
                    {
                        SceneManager.LoadScene("LargeGameScene");
                    }
                    if (mapSelect == 2)
                    {
                        SceneManager.LoadScene("ObstacleGameScene");
                    }
                    PessimoWinText.enabled = false;

                }

            }
        }
    }
}
