using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObj : MonoBehaviour
{
    public bool CanBePressed;
    public KeyCode KeyToPress;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyToPress))
        {
            if (CanBePressed)
            {
                gameObject.SetActive(false);
                GM.instance.NoteHit();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activater")
        {
            CanBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activater")
        {
            CanBePressed = false;
            GM.instance.NoteMiss();
        }
    }
}
