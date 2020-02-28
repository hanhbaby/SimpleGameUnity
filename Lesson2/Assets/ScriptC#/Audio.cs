using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    bool mPlay;
    bool mToggleChange;
    AudioSource mAudio;
    // Start is called before the first frame update
    void Start()
    {
        mAudio = gameObject.GetComponent<AudioSource>();
        mPlay = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(mPlay == true && mToggleChange == true)
        {
            mAudio.Play();
            mToggleChange = false;
        }
        if(mPlay == false && mToggleChange == true)
        {
            mAudio.Pause();
            mToggleChange = false;
        }
    }

    private void OnGUI()
    {
        mPlay = GUI.Toggle(new Rect(10, 10, 100, 30), mPlay, "Play");
        if(GUI.changed)
        {
            mToggleChange = true;
        }
    }
}
