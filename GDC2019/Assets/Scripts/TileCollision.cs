using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCollision : MonoBehaviour
{
    //Player 1 is the light player
    //Player 2 is the dark player

    public int LightFlag = 0;
    public int DarkFlag = 0;

    public Material TileDark;
    public Material TileLight;

    Renderer renderer;
    Rigidbody rigidbody;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        rigidbody = GetComponent<Rigidbody>();
    }

    //Reads if a specific player collides with tile
    void OnCollisionExit(Collision collisionInfo)
    {
        //If Player1 leaves a tile it has left before, Destroy gameobject
        if (collisionInfo.collider.tag == "Player1" && LightFlag == 1 && DarkFlag == 0)
        {
            LightFlag = 2;
            print("2");
            //rigidbody.useGravity = true;
            Destroy(gameObject);

        }

        //If Player2 leaves a tile it has left before, Destroy gameobject
        if (collisionInfo.collider.tag == "Player2" && LightFlag == 0 && DarkFlag == 1)
        {
            DarkFlag = 2;
            print("2");
      
            //rigidbody.useGravity = true;
            Destroy(gameObject);


        }

        //If player 1 leaves an untouched tile, flag becomes one and material changes to light
        if (collisionInfo.collider.tag == "Player1" && LightFlag == 0 && DarkFlag == 0)
        {
            LightFlag = 1;
            print("1");
            renderer.material = TileLight;

        }

        //If player 2 leaves an untouched tile, flag becomes one and material changes to dark
        if (collisionInfo.collider.tag == "Player2" && LightFlag == 0 && DarkFlag == 0)
        {
            DarkFlag = 1;
            print("1");
            renderer.material = TileDark;
        }                
    }
}
