using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    public Vector2 Distance;

    private Vector2 startTouchPosition;
    private Vector2 currentPosition;
    private Vector2 endTouchPosition;

    private Rigidbody rigid;

    private bool stopTouch = false;

    public GameObject start;

    public float speed;
    public float swipeRange;
    public float tapRange;

    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Swap();
    }

    public void Swap()
    {
        //Get the start touch position of the swipe
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            startTouchPosition = Input.GetTouch(0).position;

        //Update the current touch position of the swipe and verify if the swipe is in the swipe range
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentPosition = Input.GetTouch(0).position;

            if (!stopTouch && (Distance.x < -swipeRange || Distance.x > swipeRange
                                || Distance.y > swipeRange || Distance.y < -swipeRange))
                stopTouch = true;   
        }

        //Get the end touch position of the swipe, and move the ball
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) 
        {
            start.SetActive(false);

            stopTouch = false;

            endTouchPosition = Input.GetTouch(0).position;

            Distance = endTouchPosition - startTouchPosition;

            //TAP
            if (Mathf.Abs(Distance.x) < tapRange)
                Distance = Vector2.zero;

            //Move the ball
            if (Distance.x < -50)
                rigid.AddForce(Vector3.left * speed * (-Distance.x/2));
            
            if (Distance.x > 50)
                rigid.AddForce(Vector3.right * speed * (Distance.x/2));
            
            if (Distance.y < 0)
                rigid.AddForce(Vector3.back * speed * (-Distance.y/2));
            
            if (Distance.y > 0)
                rigid.AddForce(Vector3.forward * speed * (Distance.y/2));
        }
    }
}
