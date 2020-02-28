using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    public Vector2 speed;
    public int m_DistanMove;
    private static float m_Position;
    private int m_FrameMove;
    private bool IsMoveLeft;
    // Start is called before the first frame update
    void Start()
    {
        speed = new Vector2(-1, -1);
        m_DistanMove = 90;
        IsMoveLeft = false;
        m_Position = transform.position.x;
        m_FrameMove = 0;
        IsMoveLeft = true;
    }

    // Update is called once per frame
    void Update()
    {
        if ((m_FrameMove % m_DistanMove) == 0)
        {
            IsMoveLeft = !IsMoveLeft;
            m_FrameMove = 0;
        }
        if (IsMoveLeft)
        {
            transform.Translate(Vector3.left * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime);
        }
        m_FrameMove++;
    }
}
