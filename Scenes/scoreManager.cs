using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class scoreManager : MonoBehaviour
{
    public static scoreManager instance;

    public TMP_Text leftScoreText;
    public TMP_Text rightScoreText;

    int leftScore = 0;
    int rightScore = 0;
   

    private void Awake(){
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        leftScoreText.text = leftScore.ToString();
        rightScoreText.text = rightScore.ToString();
    }

    public void AddPointRight(){
        rightScore += 1;
        rightScoreText.text = rightScore.ToString();
        if(rightScore == 5){
            //display the win screen
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }

    public void AddPointLeft(){
        leftScore += 1;
        leftScoreText.text = leftScore.ToString();
        if(leftScore == 5){
            //display the win screen
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
