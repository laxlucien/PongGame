using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{
    float speed;
    float radius;
    Vector2 direction;

    Vector2 OriginalPos;

    // Start is called before the first frame update
    void Start()
    {

        direction = Vector2.one.normalized; //directyion is (1, 1) normalized
        radius = transform.localScale.x / 2; // half of the width
        speed = 10f;

        OriginalPos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        //bounce off the top and the bottom of the screen
        if(transform.position.y < GameManager.bottomLeft.y + radius && direction.y < 0){
            direction.y = -direction.y;
        }
        if(transform.position.y > GameManager.topRight.y - radius && direction.y > 0){
            direction.y = -direction.y;
        }

        //game over (Ends the game when one person scores)
        if(transform.position.x < GameManager.bottomLeft.x + radius && direction.x < 0){
            Debug.Log("Right Player Wins!!!");
            scoreManager.instance.AddPointRight();
            ResetPosition();

            //for now we just freeze the game
            //Time.timeScale = 0;
            //enabled = false; //this turns off the script

        }
        if(transform.position.x > GameManager.topRight.x - radius && direction.x > 0){
            Debug.Log("Left Player Wins!!!");
            scoreManager.instance.AddPointLeft();
            ResetPosition();

            //for now just stop the game
            //Time.timeScale = 0;
            //enabled = false; //this turns off the script
        }
    }

    //check if the blaa hits the paddle
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "paddle"){
            bool isRight = other.GetComponent<Paddle> ().isRight;

            //this is hitting the right paddle
            if(isRight == true && direction.x > 0){
                direction.x = -direction.x;
            }
            //this is hitting the left paddle
            if(isRight == false && direction.x < 0){
                direction.x = -direction.x;
            }
        }
    }

    public void ResetPosition(){
        transform.position = OriginalPos;
    }
}
