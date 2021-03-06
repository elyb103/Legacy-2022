using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChange : MonoBehaviour
{

    public Sprite spriteA;
    public Sprite spriteB;
    public Sprite spriteC;
    public Sprite spriteD;
    public Sprite spriteE;
    public Sprite spriteF;
    public Sprite spriteG;
    public Sprite spriteH;
    void Update()
    {
        if (Input.GetKeyDown(key: KeyCode.DownArrow))
        {
            GetComponent<SpriteRenderer>().sprite = spriteA;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            GetComponent<SpriteRenderer>().sprite = spriteB;
        }
        if (Input.GetKeyDown(key: KeyCode.UpArrow))
        {
            GetComponent<SpriteRenderer>().sprite = spriteC;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            GetComponent<SpriteRenderer>().sprite = spriteD;
        }
        if (Input.GetKeyDown(key: KeyCode.RightArrow))
        {
            GetComponent<SpriteRenderer>().sprite = spriteE;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            GetComponent<SpriteRenderer>().sprite = spriteF;
        }
        if (Input.GetKeyDown(key: KeyCode.LeftArrow))
        {
            GetComponent<SpriteRenderer>().sprite = spriteG;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            GetComponent<SpriteRenderer>().sprite = spriteH;
        }
    }
}

