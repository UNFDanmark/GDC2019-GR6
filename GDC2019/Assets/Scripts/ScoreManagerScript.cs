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
        if(OptimoScore == 0)
        {

        }
    }
}
