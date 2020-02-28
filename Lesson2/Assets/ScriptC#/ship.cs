using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship : MonoBehaviour
{
    public GameObject water;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            if (water)
            {
                water.GetComponent<BuoyancyEffector2D>().flowMagnitude = water.GetComponent<BuoyancyEffector2D>().flowMagnitude * (-1);
            }
            else
            {
                Debug.Log("NULllllllllllll");
            }
        }
    }
}
