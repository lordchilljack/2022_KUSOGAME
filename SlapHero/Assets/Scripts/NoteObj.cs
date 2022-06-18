using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObj : MonoBehaviour
{
    public bool CanBePressed;
    public KeyCode KeyToPress;

    public GameObject Hiteffect,GoodEffect,PerfectEffect;

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
                //GM.instance.NoteHit();
                if (Mathf.Abs(transform.position.y) > 0.75)
                {
                    GM.instance.NormalHit();
                    Instantiate(Hiteffect, transform.position, Hiteffect.transform.rotation);
                }
                else if (Mathf.Abs(transform.position.y) > 0.25)
                {
                    GM.instance.GoodHit();
                    Instantiate(GoodEffect, transform.position, GoodEffect.transform.rotation);
                }
                else
                {
                    GM.instance.PerfectHit();
                    Instantiate(PerfectEffect, transform.position, PerfectEffect.transform.rotation);
                }
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
