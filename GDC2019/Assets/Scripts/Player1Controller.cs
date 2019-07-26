using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    public float MovementSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            print("Test");
            transform.Translate(new Vector3(0, 0, MovementSpeed));
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, -MovementSpeed));
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(new Vector3(-MovementSpeed, 0, 0));
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(new Vector3(MovementSpeed, 0, 0));
        }
    }
}
