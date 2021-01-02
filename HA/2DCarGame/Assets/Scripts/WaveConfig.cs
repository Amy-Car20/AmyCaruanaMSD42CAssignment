using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Truck Wave Config")]
public class WaveConfig : ScriptableObject
{
    //the obstacle that will spawn in this wave
    [SerializeField] GameObject truckPrefab;

    //the path that the wave will follow
    [SerializeField] GameObject pathPrefab;

    //time between each truck Spawn
    [SerializeField] float timeBetweenSpawns = 0.5f;

    //random time difference between spawns
    [SerializeField] float spawnRandomFactor = 0.3f;

    //number of trucks in the Wave
    [SerializeField] int numberOfTrucks = 3;

    //the speed of the truck
    [SerializeField] float truckMoveSpeed = 2f;

    public GameObject GetTruckPrefab()
    {
        return truckPrefab;
    }

    public List<Transform> GetWaypoints()
    {
        //each wave can have different waypoints
        var waveWaypoints = new List<Transform>();

        //access pathPrefab and for each child
        //add it to the List waveWayPoints
        foreach (Transform child in pathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }

        return waveWaypoints;
    }
    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float GetSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }

    public float GetNumberOfTrucks()
    {
        return numberOfTrucks;
    }

    public float GetTruckMoveSpeed()
    {
        return truckMoveSpeed;
    }




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
