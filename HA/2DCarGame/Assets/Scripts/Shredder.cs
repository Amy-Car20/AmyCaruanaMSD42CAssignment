using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shredder : MonoBehaviour
{
    [SerializeField] int scoreValue = 5;
    //destroys bullet clones in order to avoid cluster of bullets
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        //this adds a tag to the obstacles that are avoided
        if (otherObject.gameObject.tag == "ShreddedObstacle")
        {
            Destroy(otherObject.gameObject);

            FindObjectOfType<GameSession>().AddToScore(scoreValue);
        }
        else
        {
            //the object gets destroyed and no points will be awarded since the obstacle has no tag
            Destroy(otherObject.gameObject);
        }
    }
}
