using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public GameObject Panel;
    

    public void Update()
    {
        EndGame();
    }

    public void EndGame(){
        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
            Panel.SetActive(false);
            ReloadGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
         Application.Quit();
        }   
    }
    
    // This function is called when the player's collider enters the cube's collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0;
            Panel.SetActive(true);
        
        }
    }

     private void ReloadGame()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
