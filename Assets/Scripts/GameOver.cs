using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameManager gameManager;

    private void OnCollisionEnter(Collision other)
    {
        gameManager.GameOver();
    }
}
