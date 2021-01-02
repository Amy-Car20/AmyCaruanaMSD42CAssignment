using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;
    float xMin, xMax, yMin, yMax;

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

        //could as do: var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);

        //same thing as above
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newYPos = transform.position.y + deltaY;
        newYPos = Mathf.Clamp(newYPos, yMin, yMax);

        //updates the position of the player
        transform.position = new Vector2(newXPos, newYPos);
    }
}
