using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1Script :MonoBehaviour
{
    public float MovementSpeed = 0.06f;
    public string dir = "right";
    public float DistanceCovered;

    public Vector3 StartVector;
    public Vector3 EndVector;
    public Vector3[] directions;
    public int i = 3;

    public GameManagerScript GameManager;
    public GameObject ScoreObject;

    void Start()
    {
        StartVector = transform.position;
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
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            dir = "up";
            i = 0;

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            dir = "left";
            i = 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            dir = "down";
            i = 2;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            dir = "right";
            i = 3;
        }
    }

    void MoveInDirection()
    {
        DistanceCovered = DistanceCovered + MovementSpeed;
        if (DistanceCovered > 1) //the if-statement bottlenecks Distance Covered to a max of 1
        {
            DistanceCovered = 1;
        }

        if (Vector3.Distance(StartVector, transform.position) >= 2) //if the player has moved 2 or more units away from their start position , then reset distance covered and run FindNextDestination.
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
        if (collisionInfo.collider.tag == "Player2")
        {
            ScoreObject.GetComponent<ScoreManagerScript>().OptimoScore++;
            ScoreObject.GetComponent<ScoreManagerScript>().PessimoScore++;
            SceneManager.LoadScene("GameScene");
            ScoreObject.GetComponent<ScoreManagerScript>().OptimoScore--;
            ScoreObject.GetComponent<ScoreManagerScript>().PessimoScore--;
        }
    }
}



