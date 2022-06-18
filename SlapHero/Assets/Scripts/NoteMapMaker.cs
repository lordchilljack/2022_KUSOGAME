using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMapMaker : MonoBehaviour
{
    public GameObject NoteType0;
    public GameObject NoteType1;
    public GameObject NoteType2;
    public GameObject NoteType3;

    private char[] Song01_NoteBtn = { 'G', 'H', 'G', 'K', 'H', 'G', 'H', 'J' };
    private float[] Song01_TimeStamp = {9.0f, 9.25f, 11.5f, 13.0f, 14.0f, 15.0f, 15.25f, 16.0f };

    // Start is called before the first frame update
    void Start()
    {
        int LCount = 0;
        for (LCount = 0; LCount < Song01_NoteBtn.Length; LCount++)
        {
            float PosX;
            switch (Song01_NoteBtn[LCount])
            {
                case 'G':
                    PosX = -3;
                    GameObject NewNote0 = Instantiate(NoteType0, new Vector3(PosX, Song01_TimeStamp[LCount], 0.0f), NoteType0.transform.rotation);
                    NewNote0.transform.SetParent(this.transform);
                    break;
                case 'H':
                    PosX = -1;
                    GameObject NewNote1 = Instantiate(NoteType1, new Vector3(PosX, Song01_TimeStamp[LCount], 0.0f), NoteType1.transform.rotation);
                    NewNote1.transform.SetParent(this.transform);
                    break;
                case 'J':
                    PosX = 1;
                    GameObject NewNote2 = Instantiate(NoteType2, new Vector3(PosX, Song01_TimeStamp[LCount], 0.0f), NoteType2.transform.rotation);
                    NewNote2.transform.SetParent(this.transform);
                    break;
                case 'K':
                    PosX = 3;
                    GameObject NewNote3 = Instantiate(NoteType3, new Vector3(PosX, Song01_TimeStamp[LCount], 0.0f), NoteType3.transform.rotation);
                    NewNote3.transform.SetParent(this.transform);
                    break;
            }
            
  
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
