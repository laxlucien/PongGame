using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    float speed;

    float height;

    string input;
    public bool isRight;

    // Start is called before the first frame update
    void Start()
    {
        height = transform.localScale.y;
    }

    public void Init(bool isRightPaddle){

        isRight = isRightPaddle;

        Vector2 pos = Vector2.zero;

        if(isRightPaddle){
            //place the paddle on the right of the screen
            pos = new Vector2(GameManager.topRight.x, 0);
            pos -= Vector2.right * transform.localScale.x;

            input = "PaddleRight";
        }else{
            //place the paddle on the left of the screen
            pos = new Vector2(GameManager.bottomLeft.x, 0);
            pos += Vector2.right * transform.localScale.x;

            input = "PaddleLeft";
        }
        
        //update the paddle position
        transform.position = pos;

        transform.name = input;
    }

    // Update is called once per frame
    void Update()
    {
        //now move the paddle

        //GetAxis is a number between -1 to 1 (-1 for down, 1 for up)
        float move = Input.GetAxis(input) * Time.deltaTime * speed;

        //restrict paddle movemnet
        //if paddle is tooo low then the user is stopped from moving it more
        if(transform.position.y < GameManager.bottomLeft.y + height/2 && move < 0){
            move = 0;
        }
        //if the paddle is too high then the user is stopped
        if(transform.position.y > GameManager.topRight.y - height/2 && move > 0){
            move = 0;
        }

        transform.Translate(move * Vector2.up);
    }
}
