using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private GameController _gameController;
    private Text scoreText;
    void Start()
    {
        _gameController = FindObjectOfType(typeof(GameController)) as GameController;
        scoreText = GetComponent<Text>();
    }

   
    void Update()
    {
        
    }

    void showScore()
    {
        scoreText.text = _gameController.currentScore.ToString();
        
    }
}
