using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetStar : MonoBehaviour
{
    public GameObject star;
    public GameManager gameManager;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.name == "Ball")
        {
            star.SetActive(false);
            gameManager.numberOfStars += 1;
        }
    }
}
