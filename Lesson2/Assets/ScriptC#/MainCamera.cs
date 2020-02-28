using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField]
    private float Xmin;
    [SerializeField]
    private float Xmax;
    [SerializeField]
    private float Ymin;
    [SerializeField]
    private float Ymax;
    private Transform Target;
    private Transform Snow;
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.Find("player").transform;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("quit");
        }
    }

    // Update is called once per frame

    private void LateUpdate()
    {
        if (Target)
            transform.position = new Vector3(Mathf.Clamp(Target.position.x, Xmin, Xmax), Mathf.Clamp(Target.position.y, Ymin, Ymax), transform.position.z);
      
    }
}
