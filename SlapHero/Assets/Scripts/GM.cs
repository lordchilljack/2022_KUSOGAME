using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public AudioSource TheMusic;
    public bool startPlaying;
    public BeatsScroller theBS;

    public static GM instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.WasStarted = true;

                TheMusic.Play();
            }
        }
    }
    public void NoteHit()
    {
        Debug.Log("Hit on Time");
    }
    public void NoteMiss()
    {
        Debug.Log("MIssed");
    }
}
