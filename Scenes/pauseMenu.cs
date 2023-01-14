using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    [SerializeField]
    GameObject PauseMenu;

    public void Pause(){
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void resume(){
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Home(int sceneID){
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneID);
    }
}
