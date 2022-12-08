using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    private Rigidbody2D sceneRBody;
    private GameController _gameController;

    private bool isSpawned;

    void Start()
    {
        sceneRBody = GetComponent<Rigidbody2D>();
        _gameController = FindObjectOfType<GameController>() as GameController;

        sceneMovement();

    }


    void Update()
    {
        sceneSpawn();
        sceneDestroy();
    }

    void sceneMovement()
    {
        sceneRBody.velocity = new Vector2(_gameController.speedMove, 0);
    }

    void sceneSpawn()
    {
        if(isSpawned == false && transform.position.x <= 0)
        {         
          isSpawned = true;
          int rand = Random.Range(0, 100);
            int idPrefab;

                if(rand <= 50)
                {
                idPrefab = 0;
                }
                else
                {
                idPrefab = 1;
                }

            GameObject temp = Instantiate(_gameController.prefabScenesToSpawn[idPrefab]);
            float posX = transform.position.x + _gameController.sceneSize;
            float posY = transform.position.y;
            temp.transform.position = new Vector3(posX, posY, 0);

        }
    }

    void sceneDestroy()
    {
        if( transform.position.x <= _gameController.distanceToDestroy)
        {
            Destroy(gameObject);
        }
    }
    
}
