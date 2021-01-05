using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePathing : MonoBehaviour
{
    [SerializeField] WaveConfig waveConfig;
    [SerializeField] List<Transform> waypoints;

    [SerializeField] float moveSpeed = 2f;

    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        //get the List waypoints from WaveConfig
        waypoints = waveConfig.GetWaypoints();

        //set the start position of Obstacle to the 1st waypoint
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ObstacleMove();
    }

    void ObstacleMove()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            //save the current waypoint in targetPosition
            //targetPosition: where we want to go
            var targetPosition = waypoints[waypointIndex].transform.position;

            //to make sure z position is 0	
            targetPosition.z = 0f;

            var obstacleMovement = waveConfig.GetObstacleMoveSpeed() * Time.deltaTime;

            //move from the current position, to the target position, the maximum distance one can move
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, obstacleMovement);

            //moves obstacle downwards
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -180)); 

            //if we reached the target waypoint
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        //if enemy moved to all waypoints
        else
        {
            Destroy(gameObject);
        }
    }

    // Set up a WaveConfig
    public void SetWaveConfig(WaveConfig waveConfigToSet)
    {
        waveConfig = waveConfigToSet;
    }



}
