using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shredder : MonoBehaviour
{
    [SerializeField] int scoreValue = 5;

    [SerializeField] AudioClip pointsGained;
    //allows the variable to be set in the Inspector from 0 to 1
    [SerializeField] [Range(0, 1)] float pointsGainedVolume = 0.75f;

    //destroys bullet clones in order to avoid cluster of bullets
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        //this adds a tag to the obstacles that are avoided
        if (otherObject.gameObject.tag == "ShreddedObstacle")
        {
            Destroy(otherObject.gameObject);

            //playing sound once 5 points added
            AudioSource.PlayClipAtPoint(pointsGained, Camera.main.transform.position, pointsGainedVolume);

            FindObjectOfType<GameSession>().AddToScore(scoreValue);

        }
        else
        {
            //the object gets destroyed and no points will be awarded since the obstacle has no tag
            Destroy(otherObject.gameObject);
        }
    }
}
