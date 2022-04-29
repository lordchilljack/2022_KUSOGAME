using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyTest : MonoBehaviour
{
    public Leaderboard leaderboard;
    int score = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SlapRoutine()
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(1f);
        yield return leaderboard.SubmitScoreRoutine(8964);
        Time.timeScale = 1f;
    }
}
