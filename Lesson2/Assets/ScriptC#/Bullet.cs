using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float mDistance;
    public float mSpeed;
    private Vector3 mEndpoint;
    // Start is called before the first frame update
    void Start()
    {
        mEndpoint = transform.position - new Vector3(mDistance, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * mSpeed * Time.deltaTime);

        if (transform.position.x <= mEndpoint.x)
        {
            Destroy(this.gameObject);
        }
    }
}
