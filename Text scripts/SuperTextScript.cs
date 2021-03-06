using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//**Prerequisites for code**
//Need an image object as background with a child text object overlayed, text must be the *Legacy* version
//Newer TMP text WILL NOT work!!!

//**Usage**
//Assign script to NPC sprite, put the image object as the "Dialog Box" variable, text object
// as the "Dialog Text" variable, and the text you want in the various dialogue queues.
//The same box should be able to be reused for different texts as youre setting the variable
//in the sprite and not the main script.
//

//**Planned updates**
//Making permanant changes to dialoge depending on player path choices

public class SuperTextScript : MonoBehaviour
{

    //**Variables needed to be set public**
    //Provides space to select a backround image for text and a space for text itself
    public GameObject dialogBox;
    public Text dialogText;

    //Example initial dialog queue, only one and can be named anything as long as it is consistent throughout code
    public string[] dialog;

    //Example divergent paths, no limit and can be named anything as long as they are consistent throughout code
    public string[] path1;
    public string[] path2;


    //**Variables that can ave public removed, Set public for debugging**
    //Empty queue that gets filled dynamically as needed to feed text
    public string [] arry;

    //Two counters. Unity starts at 1 so using only SentenceCount would go past bounds of array
    public int SentenceCount = 0;
    public int textEnd = 1;
    
    //Used to detect plyer status
    public bool playerInRange;
    
    

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {

        //Detects when the player is in range and if spacebar is pressed to toggle dialogue.
        //To make box automatically appear without spacebar, remove [Input.GetKeyDown(KeyCode.Space) &&]
        if(Input.GetKeyDown(KeyCode.Space) && playerInRange) {
            
            //Sets and resets initial dialog and text counters
            if(dialogBox.activeInHierarchy){
                arry = dialog;
                dialogBox.SetActive(false);
                SentenceCount = 0;
                textEnd = 1;
            }else{
                arry = dialog;
                SentenceCount = 0;
                textEnd = 1;
                dialogBox.SetActive(true);
                
                //Sets initial dialog queue
                dialogText.text = arry[SentenceCount];

            }

        }

        //Scrolls through dialog queue when a key is pressed, currently set as keyboard enter key
        if(Input.GetKeyDown(KeyCode.Return) && playerInRange && textEnd < arry.Length){
                SentenceCount ++;
                textEnd ++;
                dialogText.text = arry[SentenceCount];
        
        //Kills dialogue box once the end of a path is reached and resets counters
        //**IF PATH CHANGES add an and statement checking if "(arry == differentpathatveryend1 || arry == differentpathatveryend2)" map ALL path ends**
        //Right now there is no specific path ends specified and it will kill the dialoge box at the end of every dialog queue which can break splitting system
        }else if(Input.GetKeyDown(KeyCode.Return) && playerInRange && textEnd == arry.Length){
            dialogBox.SetActive(false);
            SentenceCount = 0;
            textEnd = 1;
        }


        //Example of splitting a path
        //Specify where in a dialogue queue you want there to be a split path and what key will
        //trigger the split.
        //Add else if statement for a different path
        //For splitting within splits make a new if statement entirely using this format.
        if(Input.GetKeyDown(KeyCode.Return) && playerInRange && arry[SentenceCount] == dialog[3]){
            
            //Sends a log that the path change has started
            Debug.Log("Path is changing");
            
            //Resets text counters, counters are 
            SentenceCount = -1;
            textEnd = 0;

            //Changes array selection
            arry = path1;

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
