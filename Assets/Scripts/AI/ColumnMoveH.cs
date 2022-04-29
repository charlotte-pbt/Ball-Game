using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnMoveH : MonoBehaviour
{
    public GameObject column;
    public float speed = 0.1f;
    public GameManager gameManager;

    public int Direction = 1;

    // Update is called once per frame
    void Update()
    {
        MoveColumn();
    }

    private void MoveColumn() 
    {
        //Move the column
        if (!gameManager.gameOver)
        {
            if (Direction == 1)
                column.transform.position += Vector3.left * speed;

            if (Direction == 0)
                column.transform.position += Vector3.right * speed;
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        //The column touch one of the two wall, so we change its direction
        
        if (other.gameObject.name == "LeftWall" || other.gameObject.name == "RightWall")
        {
            if (Direction == 0)
                Direction = 1;
            else if (Direction == 1)
                Direction = 0;
        }
    }

}
