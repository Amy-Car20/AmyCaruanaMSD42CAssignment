using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float health = 50f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f; //check

    [SerializeField] AudioClip healthReduction;
    //allows the variable to be set in the Inspector from 0 to 1
    [SerializeField] [Range(0, 1)] float healthReductionVolume = 0.75f;
    float xMin, xMax, yMin, yMax;

    [SerializeField] GameObject explosionVFX;
    [SerializeField] float explosionVFXDuration = 1f;
    
    int playerScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    //reduces health whenever the player collides with a gameObject which has DamageDealer component
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        //access the Damage Dealer from the "other" object which hit the obstacle
        DamageDealer dmgDealer = otherObject.gameObject.GetComponent<DamageDealer>();

        //if there is no dmgDealer in otherObject, end the method
        if (!dmgDealer) //if (dmgDealer == null)
        {
            return;
        }
        ProcessHit(dmgDealer);
    }

    //whenever ProcessHit is called, send the DamageDealer details
    private void ProcessHit(DamageDealer dmgDealer)
    {
        health -= dmgDealer.GetDamage();

        //instatiate explosion effects
        GameObject explosion = Instantiate(explosionVFX, transform.position, Quaternion.identity);

        //destroy after 1 second
        Destroy(explosion, explosionVFXDuration);

        //destroys the bullet on collision
        dmgDealer.Hit(); 

        if (health <= 0)
        {
            Die();
        }
    }

    //setting up the boundaries of the movement according to the camera
    private void SetUpMoveBoundaries()
    {
        //getting the camera from Unity
        Camera gameCamera = Camera.main;

        //xMin = 0  xMax = 1
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        //yMin = 0  yMax = 1
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }
    
    //moves the player around
    private void Move()
    {
        //var is used as a generic variable. VS allows us to use var and it will set its type depending on the value it will have
        //deltaX will be updated with the input that will happen on the x-axis, left and right
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        //new XPos = current x-position of player + difference in x by keyboard input
        var newXPos = transform.position.x + deltaX;

        //clamps the newXPos between xMin and xMax
        newXPos = Mathf.Clamp(newXPos, xMin, xMax);

        //could also do: var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);

        //updates the position of the player
        transform.position = new Vector2(newXPos, transform.position.y);
    }

    private void Die()
    {
        if (playerScore < 100) 
        {
            //destroys player
            Destroy(gameObject);

            //playing the sound once player dies
            AudioSource.PlayClipAtPoint(healthReduction, Camera.main.transform.position, healthReductionVolume);

            //find object of type Level in Hierarchy and run its method LoadGameOver()
            FindObjectOfType<Level>().LoadGameOver();

            //instatiate explosion effects
            GameObject explosion = Instantiate(explosionVFX, transform.position, Quaternion.identity);

            //destroy after 1 second
            Destroy(explosion, explosionVFXDuration);

        }
    }
}
