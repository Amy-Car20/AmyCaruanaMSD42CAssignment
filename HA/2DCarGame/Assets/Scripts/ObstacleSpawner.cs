using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    //a list of WaveConfigs
    [SerializeField] List<WaveConfig> waveConfigList;

    [SerializeField] bool looping = false;

    //Game always start from Wave 0
    int startingWave = 0;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            //start coroutine that spawns all waves
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping); // this is same thing as: while (looping == true)

    }

    // Update is called once per frame
    void Update()
    {

    }

    //when calling Coroutine, specify which Wave we need to spawn obstacles from
    private IEnumerator SpawnAllObstaclesInWave(WaveConfig waveToSpawn)
    {
        for (int obstacleCount = 1; obstacleCount <= waveToSpawn.GetNumberOfObstacles(); obstacleCount++)
        {
            //spawn the obstacle from waveConfig at the position specified by waveConfig waypoints
            var newObstacle = Instantiate(
                    waveToSpawn.GetObstaclePrefab(),
                    waveToSpawn.GetWaypoints()[0].transform.position, Quaternion.identity);

            //the wave will be selected from here and the enemy applied to it
            newObstacle.GetComponent<ObstaclePathing>().SetWaveConfig(waveToSpawn);


            //wait timeBetweenSpawns before spawning another enemy
            yield return new WaitForSeconds(waveToSpawn.GetTimeBetweenSpawns());
        }
    }

    private IEnumerator SpawnAllWaves()
    {
        //loop all waves
        foreach (WaveConfig currentWave in waveConfigList)
        {
            //wait for all enemies to spawn before going to the next wave
            yield return StartCoroutine(SpawnAllObstaclesInWave(currentWave));
        }

    }
}
