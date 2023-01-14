using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public Paddle paddle;

    public static Vector2 bottomLeft;
    public static Vector2 topRight;

    // Start is called before the first frame update
    void Start()
    {
        //convert the screens pixel coordinate into the games coordinate
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        //create ball
        Instantiate(ball);

        //this creates a ball and makes the two paddles that are both left and right.
        Paddle paddleLeft = Instantiate(paddle) as Paddle;
        Paddle paddleRight = Instantiate(paddle) as Paddle;
        paddleLeft.Init(true); //left paddle
        paddleRight.Init(false); //right paddle

    }

    void update(){
        if(Input.GetKey("escape")){
            Debug.Log("Game quit");
            Application.Quit();
        }
    }

}
