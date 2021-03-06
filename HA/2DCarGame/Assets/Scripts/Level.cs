﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 1f;
    IEnumerator WaitAndLoad()
    {
        //wait 2 seconds then load the GameOver scene
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("GameOver");
    }

    IEnumerator WaitAndLoadWinner()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Winner");
    }

    public void LoadStartMenu()
    {
        //loads the first scene in the Project
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        //loads the scene with name 2DCarGame
        SceneManager.LoadScene("2DCarGame");
        //resets the GameSession from the beginning
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadGameOver()
    {
        //waits 2 seconds then starts gameover
        StartCoroutine(WaitAndLoad());
    }

    public void QuitGame()
    {
        //for testing purposes
        print("Quit");

        Application.Quit();
    }

    public void LoadWinnerScene()
    {
        StartCoroutine(WaitAndLoadWinner());
    }

}
