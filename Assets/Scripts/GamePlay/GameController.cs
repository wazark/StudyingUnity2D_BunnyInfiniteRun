using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameController : MonoBehaviour
{
    [Header("Bunny Settings")]
    public float jump;
    public float runSpeed;
    public float limitMaxX;
    public float limitMinX;

    [Header("Score Settings")]
    public int currentScore;
    public int carrotScore;
    public int easterEggScore;

    [Header("Scene Settings")]
    public float speedMove;
    public float distanceToDestroy;
    public float sceneSize;
    public GameObject[] prefabScenesToSpawn;



    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void scoring( int scored)
    {
        currentScore += scored;
    }
    public void changeScene(string destinationScene)
    {
        SceneManager.LoadScene(destinationScene);
    }
        
}
