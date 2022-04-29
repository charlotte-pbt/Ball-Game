using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryBallMove : MonoBehaviour
{
    public GameObject ball;
    public float speed = 0.5f;
    public GameManager gameManager;

    public int Direction = 1;

    // Update is called once per frame
    void Update()
    {
        MoveBall();
    }

    private void MoveBall() 
    {
        //If the game is running, we move the angry ball
        if (!gameManager.gameOver)
        {
            if (Direction == 1)
            {
                ball.transform.Rotate(8f, 0f, 0f, Space.Self);
                ball.transform.position += Vector3.right * speed;
            }
            if (Direction == 0)
            {
                ball.transform.Rotate(-8f, 0f, 0f, Space.Self);
                ball.transform.position += Vector3.left * speed;
            }
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        //The angry ball touch one of the two wall, so we change its direction
        if (other.gameObject.name == "LeftWall" || other.gameObject.name == "RightWall")
        {
            if (Direction == 0)
                Direction = 1;
            else if (Direction == 1)
                Direction = 0;
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        //The player ball touch a angry ball ==> Game Over
        if (other.gameObject.name == "Ball")
            gameManager.GameOver();
    }
}
