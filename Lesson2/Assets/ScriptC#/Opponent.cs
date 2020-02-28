using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : MonoBehaviour
{
    public GameObject mBullet;
    public GameObject mstartPoint;
    public float mTimeShooting;
    private float mNextTimeShooting;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mNextTimeShooting <= Time.realtimeSinceStartup)
        {
            Instantiate(mBullet, mstartPoint.transform.position, Quaternion.identity);
            mNextTimeShooting = Time.realtimeSinceStartup + mTimeShooting;
        }
    }
}
