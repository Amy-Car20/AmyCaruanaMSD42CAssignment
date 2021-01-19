using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestroy : MonoBehaviour
{
    [SerializeField] float shotCounter;

    [SerializeField] float minTimeBetweenShots = 0.2f;

    [SerializeField] float maxTimeBetweenShots = 3f;

    [SerializeField] GameObject obstacleBulletPrefab;

    [SerializeField] float obstacleBulletSpeed = 0.3f;

    [SerializeField] AudioClip healthReduction;
    //allows the variable to be set in the Inspector from 0 to 1
    [SerializeField] [Range(0, 1)] float healthReductionVolume = 0.75f;

    [SerializeField] GameObject explosionVFX;
    [SerializeField] float explosionVFXDuration = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
