using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
       
    }

  public void Pause()// Functionality for pausing Game
{
        if (Input.GetKeyDown(KeyCode.Escape))

        {
            Time.timeScale = 0; // This will cause the game to pause, need to adjust later (Disable Movement and attack scripts when Pause), press esc to pause

            Debug.Log("The Escape Key was pressed, the game is paused");
                Instantiate(pauseMenu); // brings up our Pause Menu 
        }
}
    public void Continue() // The Continue functionality for the game (Press P to continue)
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 1;
            Debug.Log("The P Key was pressed, the game will now continue");
            Destroy(pauseMenu); // Will get rid of PauseMenu When you continue game 
        }
    }  
}
