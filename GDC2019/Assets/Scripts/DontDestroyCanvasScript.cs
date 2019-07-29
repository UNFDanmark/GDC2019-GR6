﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyCanvasScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int CanvasNo = GameObject.FindGameObjectsWithTag("Canvas").Length;
        DontDestroyOnLoad(gameObject);
        if (CanvasNo > 1)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
}