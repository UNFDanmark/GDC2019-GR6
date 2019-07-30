using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2Script : MonoBehaviour
{
    public float MovementSpeed = 0.1f;
    public string dir = "right";
    public float DistanceCovered;

    public Vector3 StartVector;
    public Vector3 EndVector;
    public Vector3[] directions;
    public int i = 3;

    public GameObject ScoreObject;
    public GameManagerScript GameManager;

    void Start()
    {
        StartVector = new Vector3(transform.position.x, 3, transform.position.z);
        EndVector = StartVector + directions[i];
        ScoreObject = GameObject.FindWithTag("ScoreManager");
    }
    void Update()
    {
        if (GameManager.HasGameStarted == true)
        {
            UpdateDirection();
            MoveInDirection(); 
        }
    }

   
    void UpdateDirection()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            dir = "up";
            i = 0;
            transform.eulerAngles = new Vector3(0, 270, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            dir = "left";
            i = 1;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            dir = "down";
            i = 2;
            transform.eulerAngles = new Vector3(0, 90, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            dir = "right";
            i = 3;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    void MoveInDirection()
    {
        DistanceCovered = DistanceCovered + MovementSpeed;
        if(DistanceCovered > 1) //the if-statement bottlenecks Distance Covered to a max of 1
        {
            DistanceCovered = 1;
        }

        if (Vector3.Distance(StartVector,transform.position) >= 2) //if the player has moved 2 or more units away from their start position , then reset distance covered and run FindNextDestination.
        {
            DistanceCovered = 0;
            FindNextDestination();
        }
        transform.position = Vector3.Lerp(StartVector, EndVector, DistanceCovered); //moves the player according to percentage from a to b
    }

    void FindNextDestination() //makes sure the player doesn't go further than the endvector, creates new vectors.
    {
        transform.position = EndVector;
        StartVector = transform.position;
        EndVector = StartVector + directions[i];
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Player1")
        {
            GameObject[] ScoreManagers = GameObject.FindGameObjectsWithTag("ScoreManager");
            int scoreManagerNo = ScoreManagers.Length;
            if (scoreManagerNo > 1)
            {
                ScoreObject.GetComponent<ScoreManagerScript>().OptimoScore++;
                ScoreObject.GetComponent<ScoreManagerScript>().PessimoScore++;
                int mapSelected = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>().mapSelect;
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
                ScoreObject.GetComponent<ScoreManagerScript>().OptimoScore--;
                ScoreObject.GetComponent<ScoreManagerScript>().PessimoScore--;

            }

        }
    }
}

