using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GM : MonoBehaviour
{
    public AudioSource TheMusic;
    public bool startPlaying;
    public BeatsScroller theBS;

    public static GM instance;

    public int CurrentScore;
    public int ScorePerNotes = 100;
    public int ScorePerGoodNotes = 120;
    public int scorePerPerfectNotes = 180;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI multiplerText;
    public int Currentmultipler;
    public int MultiplerTracker;
    public int[] MultiplerThreshold;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = "Score: 0";
        Currentmultipler = 1;
        multiplerText.text = "Multipler: x" + Currentmultipler;
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
        if (Currentmultipler -1 < MultiplerThreshold.Length)
        { 
            MultiplerTracker++;
            if (MultiplerThreshold[Currentmultipler - 1] <= MultiplerTracker)
            {
            MultiplerTracker = 0;
            Currentmultipler++;
            }
        }
        multiplerText.text = "Multipler: x" + Currentmultipler;
        //
        // Original normal hit score add function
        //
        //CurrentScore += ScorePerNotes * Currentmultipler;
        scoreText.text= "Score: " + CurrentScore;
       
    }

    public void NormalHit()
    {
        CurrentScore += ScorePerNotes * Currentmultipler;
        NoteHit();
    }

    public void GoodHit()
    {
        Debug.Log("Good");
        CurrentScore += ScorePerGoodNotes * Currentmultipler;
        NoteHit();
    }

    public void PerfectHit()
    {
        Debug.Log("Perfect");
        CurrentScore += scorePerPerfectNotes * Currentmultipler;
        NoteHit();
    }

    public void NoteMiss()
    {
        Debug.Log("MIssed");
        Currentmultipler = 1;
        MultiplerTracker = 0;
        multiplerText.text = "Multipler: x" + Currentmultipler;
    }
}
