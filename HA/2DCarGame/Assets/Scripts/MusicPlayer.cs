using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // runs before 'Start()'
    void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        //GetType(): gets the type of Object attached to this script: MusicPlayer       
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            //if there is more than 1 MusicPlayer in the Scene then, destroy the last one
            Destroy(gameObject);
        }
        else
        {
            //Do not destroy the MusicPlayer gameObject when changing scenes
            DontDestroyOnLoad(gameObject);
        }

    }
    


    // Update is called once per frame
    void Update()
    {
        
    }
}
