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

    public int Currentmultipler;
    public int MultiplerTracker;
    public int[] MultiplerThreshold;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI multiplerText;

    public float TotalNotes;
    public float NormalHits = 0.0f;
    public float GoodHits = 0.0f; 
    public float PerfectHits = 0.0f;
    public float MissHits = 0.0f;

    public GameObject ResultScreen;
    public TextMeshProUGUI PercentageText, NormalHitsText, GoodHitsText, PerfectHitsText, MissedHitsText,RankText,FinalScoreText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = "Score: 0";
        Currentmultipler = 1;
        multiplerText.text = "Multipler: x" + Currentmultipler;
        TotalNotes = FindObjectsOfType<NoteObj>().Length;
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
        else
        {
            if (!TheMusic.isPlaying && !ResultScreen.activeInHierarchy)
            {
                ResultScreen.SetActive(true);
                scoreText.enabled=false;
                multiplerText.enabled = false;
                NormalHitsText.text = NormalHits.ToString();
                GoodHitsText.text = GoodHits.ToString();
                PerfectHitsText.text = PerfectHits.ToString();
                MissedHitsText.text = MissHits.ToString();

                float TotalHits = NormalHits + GoodHits + PerfectHits;
                float percentageHits = (TotalHits / TotalNotes) * 100f;

                PercentageText.text = percentageHits.ToString("f2") + "%";

                string RankValue = "F";
                if (percentageHits > 40)
                {
                    RankValue = "D";
                    if (percentageHits > 55)
                    {
                        RankValue = "C";
                        if (percentageHits > 70)
                        {
                            RankValue = "B";
                            if (percentageHits > 85)
                            {
                                RankValue = "A";
                                if (percentageHits > 95)
                                {
                                    RankValue = "S";
                                }
                            }
                        }
                    }
                }
                RankText.text = RankValue;
                FinalScoreText.text = CurrentScore.ToString();
            }
        }
    }
    public void NoteHit()
    {
        //Debug.Log("Hit on Time");
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

        NormalHits++;
    }

    public void GoodHit()
    {
        //Debug.Log("Good");
        CurrentScore += ScorePerGoodNotes * Currentmultipler;
        NoteHit();
        GoodHits++;
    }

    public void PerfectHit()
    {
       //Debug.Log("Perfect");
        CurrentScore += scorePerPerfectNotes * Currentmultipler;
        NoteHit();
        PerfectHits++;
    }

    public void NoteMiss()
    {
        //Debug.Log("MIssed");
        Currentmultipler = 1;
        MultiplerTracker = 0;
        multiplerText.text = "Multipler: x" + Currentmultipler;
        MissHits++;
    }
}
