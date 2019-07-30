using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TileScript : MonoBehaviour
{
    //Player 1 is the light player
    //Player 2 is the dark player

    public int LightFlag = 0;
    public int DarkFlag = 0;

    public Material TileDark;
    public Material TileLight;
    public GameObject DeathTrigger;
    public GameObject LightTileDeathTrigger;
    public GameObject DarkTileDeathTrigger;

    public float FallDelay = 3;
    public float FallTimestamp;

    public GameObject ScoreObject;

    Renderer Painter;
    Rigidbody Rigid;
    public int mapSelected;

    void Start()
    {
        Painter = GetComponent<Renderer>();
        Rigid = GetComponent<Rigidbody>();
        ScoreObject = GameObject.FindWithTag("ScoreManager");
    }

    //Reads if a specific player collides with tile
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        int mapSelect = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>().mapSelect;
        if (collisionInfo.collider.tag == "Player1" && LightFlag == 0 && DarkFlag == 0)
        {

            
            Painter.material = TileLight;
            
        }

        //If player 2 leaves an untouched tile, flag becomes one and material changes to dark
        if (collisionInfo.collider.tag == "Player2" && LightFlag == 0 && DarkFlag == 0)
        {
            

            Painter.material = TileDark;
            
        }
    }
    void OnCollisionExit(Collision collisionInfo)
    {
        int mapSelected = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>().mapSelect;
        //If Player1 leaves a tile it has left before, Destroy gameobject
        if (collisionInfo.collider.tag == "Player1" && LightFlag == 1 && DarkFlag == 0)
        {
            LightFlag = 2;
            FallTimestamp = Time.time;

            Rigid.useGravity = true;
            print("heyo");
            Rigid.isKinematic = false;

            Instantiate(DeathTrigger, new Vector3(transform.position.x, 3, transform.position.z), Quaternion.identity);

            if (FallTimestamp + FallDelay <= Time.time)
            {
                Destroy(gameObject);
            }
        }

        //If Player2 leaves a tile it has left before, Destroy gameobject
        if (collisionInfo.collider.tag == "Player2" && LightFlag == 0 && DarkFlag == 1)
        {
            DarkFlag = 2;

            FallTimestamp = Time.time;

            Rigid.useGravity = true;
            Rigid.isKinematic = false;

            

            if (FallTimestamp + FallDelay <= Time.time)
            {
                Destroy(gameObject);
            }

        }

        //If player 1 leaves an untouched tile, flag becomes one and material changes to light
        if (collisionInfo.collider.tag == "Player1" && LightFlag == 0 && DarkFlag == 0)
        {
            LightFlag = 1;
            

        }

        //If player 2 leaves an untouched tile, flag becomes one and material changes to dark
        if (collisionInfo.collider.tag == "Player2" && LightFlag == 0 && DarkFlag == 0)
        {
            DarkFlag = 1;
            
        }

        
        

        else if (collisionInfo.collider.tag == "Player2" && LightFlag == 1 && DarkFlag == 0)
        {
            if (ScoreObject.GetComponent<ScoreManagerScript>().PessimoScore < 4 && ScoreObject.GetComponent<ScoreManagerScript>().OptimoScore < 4)
            {
                ScoreObject.GetComponent<ScoreManagerScript>().OptimoScore++;

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
        else if (collisionInfo.collider.tag == "Player1" && LightFlag == 0 && DarkFlag == 1)
        {
            if (ScoreObject.GetComponent<ScoreManagerScript>().PessimoScore < 4 && ScoreObject.GetComponent<ScoreManagerScript>().OptimoScore < 4)
            {
                ScoreObject.GetComponent<ScoreManagerScript>().PessimoScore++;
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

}
