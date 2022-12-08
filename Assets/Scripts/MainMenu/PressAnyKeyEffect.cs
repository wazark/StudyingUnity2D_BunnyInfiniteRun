using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PressAnyKeyEffect : MonoBehaviour
{
    public Text txtEffect;
    private bool isActived;
    public bool isSpacePressed;    
    public float pulsarSpeed;
    void Start()
    {
        
        StartCoroutine("pressButtonAnimation");        
        txtEffect = GetComponent<Text>();      

    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isSpacePressed= true;            
        }
        
    }
    IEnumerator pressButtonAnimation()
    {
        yield return new WaitForSecondsRealtime(pulsarSpeed);
        if(isSpacePressed == true)
        {
            txtEffect.enabled= false;
        }
        if (isSpacePressed == false && isActived == false)
        {
            isActived = true;    
            txtEffect.transform.localScale = new Vector3(0.95f, 0.95f, 0.95f);            
            StartCoroutine("pressButtonAnimation");
        }
        else if (isSpacePressed == false && isActived == true)
        {
            isActived = false;
            txtEffect.transform.localScale = new Vector3(1f, 1f, 1f);            
            StartCoroutine("pressButtonAnimation");
        }
        
    }     
}
