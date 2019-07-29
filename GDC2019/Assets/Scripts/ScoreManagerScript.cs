using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManagerScript : MonoBehaviour
{
    public int OptimoScore;
    public int PessimoScore;

    public Text OptimoScoreText;
    public Text PessimoScoreText;

    public Text OptimoWinText;
    public Text PessimoWinText;

    public int delay;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OptimoScoreFunction();
        PessimoScoreFunction();
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

        if (OptimoScore == 2)
        {
            OptimoScoreText.text = "2 - Optimo";
        }

        if (OptimoScore == 3)
        {
            OptimoScoreText.text = "3 - Optimo";
            OptimoWinText.enabled = true;
            float WinTime = Time.time;
            if (Time.time > WinTime + delay || Input.GetKey(KeyCode.Return))
            {
                OptimoScore = 0;
                PessimoScore = 0;
                SceneManager.LoadScene("GameScene");

            }

        }
    }

    public void PessimoScoreFunction()
    {
        if (PessimoScore == 0)
        {
            PessimoScoreText.text = "0 - Pessimo";
        }

        if (PessimoScore == 1)
        {
            PessimoScoreText.text = "1 - Pessimo";
        }

        if (PessimoScore == 2)
        {
            PessimoScoreText.text = "2 - Pessimo";
        }

        if (PessimoScore == 3)
        {
            PessimoScoreText.text = "3 - Pessimo";
            PessimoWinText.enabled = true;
            float WinTime = Time.time;
            if (Time.time > WinTime + delay || Input.GetKey(KeyCode.Return))
            {
                OptimoScore = 0;
                PessimoScore = 0;
                SceneManager.LoadScene("GameScene");

            }
        }
    }
}
