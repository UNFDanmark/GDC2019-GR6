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

    public Vector3 startUIPosition;
    public void OptimoYeet()
    {
        optimoWinImage.GetComponent<RectTransform>().position = new Vector3(9000,0);
        print("yeet o");
    }
    public void OptimoUnYeet()
    {
        print("un yeet o");
        optimoWinImage.GetComponent<RectTransform>().position = startUIPosition;//optimoWinImage.GetComponent<RectTransform>().sizeDelta / 2f;
    }
    public void PessimoYeet()
    {
        pessimoWinImage.GetComponent<RectTransform>().position = new Vector3(9000, 0);
        print("yeet p");
    }
    public void PessimoUnYeet()
    {
        print("un yeet o");
        pessimoWinImage.GetComponent<RectTransform>().position = startUIPosition;//optimoWinImage.GetComponent<RectTransform>().sizeDelta / 2f;
    }
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
        startUIPosition = optimoWinImage.GetComponent<RectTransform>().position;

        OptimoYeet();
        PessimoYeet();
        aS = GetComponent<AudioSource>();
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
            


            if (hasAlreadyPlayedWon == false)
            {
                aS.Stop();
                aS.PlayOneShot(audioOptimoWin);
                hasAlreadyPlayedWon = true;
                timeWon = Time.time;
                OptimoUnYeet();

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
                

            }

        }
        if (OptimoScore == 3 && roundsSelected == 1)
        {
            OptimoScoreText.text = "3 - Optimo";
            

            if (hasAlreadyPlayedWon == false)
            {
                aS.Stop();
                aS.PlayOneShot(audioOptimoWin);
                hasAlreadyPlayedWon = true;
                timeWon = Time.time;
                OptimoUnYeet();

            }


            if (Input.GetKey(KeyCode.G) || Time.time > timeWon + winDelay)
            {
                OptimoScore = 0;
                PessimoScore = 0;
                hasAlreadyPlayedWon = false;
                OptimoYeet();
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
                
            }

        }

        if (OptimoScore == 4 && roundsSelected == 2)
        {
            OptimoScoreText.text = "4 - Optimo";
            

            if (hasAlreadyPlayedWon == false)
            {
                aS.Stop();
                aS.PlayOneShot(audioOptimoWin);
                hasAlreadyPlayedWon = true;
                timeWon = Time.time;
OptimoUnYeet();

            }


            if (Input.GetKey(KeyCode.G) || Time.time > timeWon + winDelay)
            {
                OptimoScore = 0;
                PessimoScore = 0;
                hasAlreadyPlayedWon = false;
                OptimoUnYeet();
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
            PessimoScoreText.text = "Pessimo - 2";
            
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
                PessimoUnYeet();

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
                

            }

        }
        if (PessimoScore == 3 && roundsSelected == 1)
        {
            PessimoScoreText.text = "Pessimo 3";
            

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
                PessimoUnYeet();
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
                

            }

        }
        if (PessimoScore == 4 && roundsSelected == 2)
        {
            PessimoScoreText.text = "Pessimo - 4";
            
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
                PessimoUnYeet();

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
                

            }

        }
    }
}
