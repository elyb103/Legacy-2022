using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//**Prerequisites for code**
//Need an image object as background with a child text object overlayed, text must be the *Legacy* version
//Newer TMP text WILL NOT work!!!
//Lastly, set parent image object as unseen to start.

//**Usage**
//Assign script to NPC sprite, put the image object as the "Dialog Box" variable, text object
// as the "Dialog Text" variable, and the text you want in the "Dialog" variable.
//The same box should be able to be reused for different texts as youre setting the variable
//in the sprite and not the main script

//**Planned updates**
//Switching Dialoge variable to strings within script for continious text.

public class Texts : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool playerInRange;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {

        //Detects when the player is in range and if spacebar is pressed to toggle dialogue.
        //To make box automatically appear without spacebar, remove [Input.GetKeyDown(KeyCode.Space) &&]
        if(Input.GetKeyDown(KeyCode.Space) && playerInRange) {

            if(dialogBox.activeInHierarchy){
                dialogBox.SetActive(false);
            }else{
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }

        }
    }

    //Tests if player is in range
    private void OnTriggerEnter2D(Collider2D other) {

        if(other.CompareTag("Player")) {

            Debug.Log("Player in range");
            playerInRange = true;
        }

    }

    //Tests specifically if the player has left the range of detection, and removes dialoge box
    private void OnTriggerExit2D(Collider2D other) {

        if(other.CompareTag("Player")) {

            Debug.Log("Player left range");
            playerInRange = false;
            dialogBox.SetActive(false);
        }

    }



}
