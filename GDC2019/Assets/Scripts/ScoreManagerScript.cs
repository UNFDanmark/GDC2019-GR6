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
    public AudioClip audioOptimoWin;
    public AudioClip audioPessimoWin;
    public AudioClip audioPause;
    public AudioClip audioSoundtrack;
    AudioSource aS;

    bool hasAlreadyPlayedWon = false;
    float timeWon;
    float winDelay = 4;
    public GameObject pessimoWinImage;
    public GameObject optimoWinImage;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void OnSceneChange(string sceneName) {
        if (sceneName == "GameScene")
        {
            aS.clip = audioSoundtrack;
            aS.Play();
        } else if (sceneName == "LargeGameScene")
        {
            aS.clip = audioSoundtrack;
            aS.Play();
        }
        else if (sceneName == "MenuScene")
        {
            aS.clip = audioPause;
            aS.Play();
        }
        else if (sceneName == "ObstacleGameScene")
        {
            aS.clip = audioSoundtrack;
            aS.Play();
        }
        else if (sceneName == "OptimoWinScene")
        {
            aS.clip = audioSoundtrack;
            aS.Play();
        }
        else if (sceneName == "PessimoWinScene")
        {
            aS.clip = audioSoundtrack;
            aS.Play();
        }
    }

    void Start()
    {

        aS = GetComponent<AudioSource>();
        GameObject[] ScoreManagers = GameObject.FindGameObjectsWithTag("ScoreManager");
        int scoreManagerNo = ScoreManagers.Length;
        if (scoreManagerNo > 1)
        {
            if (ScoreManagers[0].GetComponent<ScoreManagerScript>().OptimoScore + ScoreManagers[0].GetComponent<ScoreManagerScript>().PessimoScore < ScoreManagers[1].GetComponent<ScoreManagerScript>().OptimoScore + ScoreManagers[1].GetComponent<ScoreManagerScript>().PessimoScore)
            {
                OptimoWinText.enabled = false;
                PessimoWinText.enabled = false;
                Destroy(ScoreManagers[0]);

            }

            else
            {
                OptimoWinText.enabled = false;
                PessimoWinText.enabled = false;
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
            GetComponent<AudioClip>();
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
            optimoWinImage.SetActive(true);
            
            if(hasAlreadyPlayedWon == false)
            {
                aS.Stop();
                aS.PlayOneShot(audioOptimoWin);
                hasAlreadyPlayedWon = true;
                timeWon = Time.time;
                

            }
            
            
            if (Input.GetKey(KeyCode.G) || Time.time > timeWon + winDelay)
            {
                OptimoScore = 0;
                PessimoScore = 0;
                hasAlreadyPlayedWon = false;

                if (mapSelect == 0)
                {
                    SceneManager.LoadScene("GameScene");
                    GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>().OnSceneChange("GameScene");
                }
                if (mapSelect == 1)
                {
                    SceneManager.LoadScene("LargeGameScene");
                    GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>().OnSceneChange("LargeGameScene");
                }
                if (mapSelect == 2)
                {
                    SceneManager.LoadScene("ObstacleGameScene");
                    GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>().OnSceneChange("ObstacleGameScene");
                }
                optimoWinImage.SetActive(false);

            }

        }
        if (OptimoScore == 3 && roundsSelected == 1)
        {
            OptimoScoreText.text = "3 - Optimo";
            optimoWinImage.SetActive(true);

            if (hasAlreadyPlayedWon == false)
            {
                aS.Stop();
                aS.PlayOneShot(audioOptimoWin);
                hasAlreadyPlayedWon = true;
                timeWon = Time.time;


            }


            if (Input.GetKey(KeyCode.G) || Time.time > timeWon + winDelay)
            {
                OptimoScore = 0;
                PessimoScore = 0;
                hasAlreadyPlayedWon = false;

                if (mapSelect == 0)
                {
                    SceneManager.LoadScene("GameScene");
                    GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>().OnSceneChange("GameScene");
                }
                if (mapSelect == 1)
                {
                    SceneManager.LoadScene("LargeGameScene");
                    GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>().OnSceneChange("LargeGameScene");
                }
                if (mapSelect == 2)
                {
                    SceneManager.LoadScene("ObstacleGameScene");
                    GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>().OnSceneChange("ObstacleGameScene");
                }
                OptimoWinText.enabled = false;
                optimoWinImage.SetActive(false);
            }

        }

        if (OptimoScore == 4 && roundsSelected == 2)
        {
            OptimoScoreText.text = "4 - Optimo";
            OptimoWinText.enabled = true;
            optimoWinImage.SetActive(false);
            if (hasAlreadyPlayedWon == false)
            {
                aS.Stop();
                aS.PlayOneShot(audioOptimoWin);
                hasAlreadyPlayedWon = true;
                timeWon = Time.time;


            }


            if (Input.GetKey(KeyCode.G) || Time.time > timeWon + winDelay)
            {
                OptimoScore = 0;
                PessimoScore = 0;
                hasAlreadyPlayedWon = false;

                if (mapSelect == 0)
                {
                    SceneManager.LoadScene("GameScene");
                    GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>().OnSceneChange("GameScene");
                }
                if (mapSelect == 1)
                {
                    SceneManager.LoadScene("LargeGameScene");
                    GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>().OnSceneChange("LargeGameScene");
                }
                if (mapSelect == 2)
                {
                    SceneManager.LoadScene("ObstacleGameScene");
                    GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>().OnSceneChange("ObstacleGameScene");
                }
                optimoWinImage.SetActive(false);

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
            pessimoWinImage.SetActive(true);
            if (hasAlreadyPlayedWon == false)
            {
                aS.Stop();
                aS.PlayOneShot(audioPessimoWin);
                hasAlreadyPlayedWon = true;
                timeWon = Time.time;


            }


            if (Input.GetKey(KeyCode.G) || Time.time > timeWon + winDelay)
            {
                OptimoScore = 0;
                PessimoScore = 0;
                hasAlreadyPlayedWon = false;

                if (mapSelect == 0)
                {
                    SceneManager.LoadScene("GameScene");
                    GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>().OnSceneChange("GameScene");
                }
                if (mapSelect == 1)
                {
                    SceneManager.LoadScene("LargeGameScene");
                    GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>().OnSceneChange("LargeGameScene");
                }
                if (mapSelect == 2)
                {
                    SceneManager.LoadScene("ObstacleGameScene");
                    GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>().OnSceneChange("ObstacleGameScene");
                }
                pessimoWinImage.SetActive(false);

            }

        }
        if (PessimoScore == 3 && roundsSelected == 1)
        {
            PessimoScoreText.text = "3 - Optimo";
            PessimoWinText.enabled = true;
            pessimoWinImage.SetActive(true);

            if (hasAlreadyPlayedWon == false)
            {
                aS.Stop();
                aS.PlayOneShot(audioPessimoWin);
                hasAlreadyPlayedWon = true;
                timeWon = Time.time;


            }


            if (Input.GetKey(KeyCode.G) || Time.time > timeWon + winDelay)
            {
                OptimoScore = 0;
                PessimoScore = 0;
                hasAlreadyPlayedWon = false;

                if (mapSelect == 0)
                {
                    SceneManager.LoadScene("GameScene");
                    GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>().OnSceneChange("GameScene");
                }
                if (mapSelect == 1)
                {
                    SceneManager.LoadScene("LargeGameScene");
                    GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>().OnSceneChange("LargeGameScene");
                }
                if (mapSelect == 2)
                {
                    SceneManager.LoadScene("ObstacleGameScene");
                    GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>().OnSceneChange("ObstacleGameScene");
                }
                pessimoWinImage.SetActive(false);

            }

        }
        if (PessimoScore == 4 && roundsSelected == 2)
        {
            PessimoScoreText.text = "4 - Optimo";
            PessimoWinText.enabled = true;
            pessimoWinImage.SetActive(true);
            if (hasAlreadyPlayedWon == false)
            {
                aS.Stop();
                aS.PlayOneShot(audioPessimoWin);
                hasAlreadyPlayedWon = true;
                timeWon = Time.time;


            }


            if (Input.GetKey(KeyCode.G) || Time.time > timeWon + winDelay)
            {
                OptimoScore = 0;
                PessimoScore = 0;
                hasAlreadyPlayedWon = false;

                if (mapSelect == 0)
                {
                    SceneManager.LoadScene("GameScene");
                    GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>().OnSceneChange("GameScene");
                }
                if (mapSelect == 1)
                {
                    SceneManager.LoadScene("LargeGameScene");
                    GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>().OnSceneChange("LargeGameScene");
                }
                if (mapSelect == 2)
                {
                    SceneManager.LoadScene("ObstacleGameScene");
                    GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>().OnSceneChange("ObstacleGameScene");
                }
                pessimoWinImage.SetActive(false);

            }

        }
    }
}
