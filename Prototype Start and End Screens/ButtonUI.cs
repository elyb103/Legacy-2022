using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{

    public string levelName;

    // Update is called once per frame
    public void loadlevel()
    {
        SceneManager.LoadScene(levelName);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
