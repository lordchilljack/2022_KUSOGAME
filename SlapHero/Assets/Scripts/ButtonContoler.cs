using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonContoler : MonoBehaviour
{
    private SpriteRenderer SpriteR;
    public Sprite DefaultImg;
    public Sprite PressedImage;

    public KeyCode KeyToPress;

    // Start is called before the first frame update
    void Start()
    {
        SpriteR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyToPress))
        {
            SpriteR.sprite = PressedImage;
        }

        if (Input.GetKeyUp(KeyToPress))
        {
            SpriteR.sprite = DefaultImg;
        }

    }
}