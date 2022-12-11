using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Bunny Settings")]
    public AudioClip sfxJump;
    public float jump;
    public float runSpeed;
    public float limitMaxX;
    public float limitMinX;

    [Header("Score Settings")]
    public int currentScore;    
    public Text scoreText;

    [Header("Scene Settings")]
    public float speedMove;
    public float distanceToDestroy;
    public float sceneSize;
    public GameObject[] prefabScenesToSpawn;

    [Header("SFX Settings")]
    public AudioSource sfxSource;
    public AudioClip sfxPoints;

    [Header("Fire Carrots Settings")]
    public AudioClip sfxFireCarrot;
    public int carrotBullet;
    public int maxAmmo;
    public float shootDelay;




    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void scoring( int scored)
    {
        currentScore += scored;
        scoreText.text = currentScore.ToString();
        sfxSource.PlayOneShot(sfxPoints);
    }
    public void changeScene(string destinationScene)
    {
        SceneManager.LoadScene(destinationScene);
    }
    public void currentAmmo(int amount)
    {              
        carrotBullet += amount;
        if(carrotBullet> maxAmmo) 
        {
            carrotBullet = maxAmmo;   
        }
    }

}
