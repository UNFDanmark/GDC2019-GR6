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
    public Rigidbody rigid;


    //public int[] rotArray = {3,0,1,2,1,3,2,0,0,2,3,1,2,1,0,3};

    public float rotationSpeed = 5;
    public int arrayTracker = 1;
    Vector3 currentDir;

    void Start()
    {
        StartVector = transform.position;
        EndVector = StartVector + directions[i];
        ScoreObject = GameObject.FindWithTag("ScoreManager");
        rigid = GetComponent<Rigidbody>();
        //from = gameObject.transform.forward;
        //to = directions[i];

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
            transform.eulerAngles = new Vector3(0,90,0);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            dir = "left";
            i = 1;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            dir = "down";
            i = 2;
            transform.eulerAngles = new Vector3(0, 270, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            dir = "right";
            i = 3;
            transform.eulerAngles = new Vector3(0, 180, 0);
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
            /*Vector3 rotVect = currentDir.normalized - directions[i].normalized;
            arrayTracker = (int)(8 * currentDir.normalized.x + 4 * currentDir.normalized.z + 2 * directions[i].x + directions[i].z);
            if (rotArray[arrayTracker] == 0)
            {
                transform.eulerAngles = new Vector3(0, 90, 0);
            }
            else if (rotArray[arrayTracker] == 1)
            {
                transform.eulerAngles = new Vector3(0, -90, 0);
            }
            else if (rotArray[arrayTracker] == 2)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            */
            FindNextDestination();
        }
        transform.position = Vector3.Lerp(StartVector, EndVector, DistanceCovered); //moves the player according to percentage from a to b
        print(rigid.velocity);
    }

    void FindNextDestination() //makes sure the player doesn't go further than the endvector, creates new vectors.
    {
        //currentDir = EndVector - StartVector;
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



