using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PressAnyKeyEffect : MonoBehaviour
{
    public Button btnEffect;
    public Button[] btnMenu;

    private bool isActived;
    void Start()
    {
        btnMenu[0].enabled= false;
        btnMenu[1].enabled = false;
        StartCoroutine("pressButtonAnimation");
    }
IEnumerator pressButtonAnimation()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        if( Input.anyKeyDown)
        {
            btnEffect.enabled = false;
            btnMenu[0].enabled = true;
            btnMenu[1].enabled = true;
        }
        if (isActived == false)
        {
            isActived = true;    
            btnEffect.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);

            StartCoroutine("pressButtonAnimation");
        }
        else
        {
            isActived = false;
            btnEffect.transform.localScale = new Vector3(1f, 1f, 1f);
            StartCoroutine("pressButtonAnimation");
        }
        
    }     
}
