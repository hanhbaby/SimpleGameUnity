using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIhandle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnReplayClick()
    {
        Application.LoadLevel("Gameplay");
    }
}
