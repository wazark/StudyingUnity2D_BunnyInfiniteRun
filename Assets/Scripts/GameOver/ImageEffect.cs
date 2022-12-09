using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageEffect : MonoBehaviour
{
    private Image gameOverImg;
    public Vector3 defaultScale;
    public Vector3 imgDecrementScale;
    public float timer;
    void Start()
    {
        gameOverImg = GetComponent<Image>();
        StartCoroutine("imageScale");

    }

    
    void Update()
    {
        
    }

    IEnumerator imageScale()
    {
        yield return new WaitForSeconds(timer);

        if (gameOverImg.rectTransform.localScale != defaultScale)
        {
            gameOverImg.rectTransform.localScale += imgDecrementScale;
            StartCoroutine("imageScale");
        }
        else if(gameOverImg.rectTransform.localScale == defaultScale)
        {
            StopCoroutine("imageScale");
        }
    }
}
