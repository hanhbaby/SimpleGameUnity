﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnStartClick()
    {
        Application.LoadLevel("LoadingLevel");
    }
    public void OnQuit()
    {
        Application.Quit();
        Debug.Log("QuitGame");
    }
}
