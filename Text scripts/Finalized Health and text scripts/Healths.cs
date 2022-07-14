using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healths : MonoBehaviour



{
public GameObject healthBox;
public Text Playertxt;
public Text NPCtxt;
private int Pinfest = 0;
private int minpercent = 0;
private string Pinfesttxt;
private int Ninfest = 0;
private string Ninfesttxt;





    // Start is called before the first frame update
    private void Start()
    {
        Pinfest = minpercent;
        Ninfest = minpercent;

    }


    // Update is called once per frame
    void Update()
    {
        Pinfesttxt = Pinfest.ToString();
        Ninfesttxt = Ninfest.ToString();
        
        Playertxt.text = ("Player Cloning: "+Pinfesttxt+"%");
        NPCtxt.text = ("School Cloning: "+Ninfesttxt+"%");
    }

    public void UpdatePlayer(int mod) {
        Pinfest += mod;

        if (Pinfest < minpercent)  {
            Pinfest = minpercent;
        } else if (Pinfest >= 100) {
            Pinfest = 100;
            Debug.Log("player loss");
        }
    }

     public void UpdateNPC(int Nmod) {
        Ninfest += Nmod;

        if (Ninfest < minpercent)  {
            Ninfest = minpercent;
        } else if (Ninfest >= 100) {
            Ninfest = 100;
            Debug.Log("NPC total loss");
        }
    }



}
