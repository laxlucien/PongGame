using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame(){
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void backToMenu(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
    
    public void backToMenuR(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
}
