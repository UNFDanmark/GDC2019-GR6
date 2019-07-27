using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Script : MonoBehaviour
{
    public float MovementSpeed = 0.1f;
    public string dir = "left";
    public bool AllowMove;
    public float DistanceCovered;

    public Vector3 StartVector;
    public Vector3 EndVector;
    public Vector3[] directions;
    public int i = 1;

    public GameManagerScript GameManager;

    void Start()
    {
        StartVector = new Vector3(transform.position.x, 3, transform.position.z);
        EndVector = StartVector + directions[i];

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

        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            dir = "left";
            i = 1;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            dir = "down";
            i = 2;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            dir = "right";
            i = 3;
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

}

