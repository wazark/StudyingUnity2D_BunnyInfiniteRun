using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowButtonMainMenu : MonoBehaviour
{
    public Button button;
    private PressAnyKeyEffect _pressAnyKey;
    public Vector3 zeroScale;
    public Vector3 incrementScale;
    public Vector3 defaultScale;
    void Start()
    {
        button = GetComponent<Button>();
        button.transform.localScale = zeroScale;
        _pressAnyKey = FindObjectOfType<PressAnyKeyEffect>() as PressAnyKeyEffect ;

        StartCoroutine("btnScale");
    }
        
   

    IEnumerator btnScale()
    {
        yield return new WaitForSeconds(0.05f);

        if (_pressAnyKey.isSpacePressed == true)
        {
            
            button.transform.localScale += incrementScale;

            if(button.transform.localScale == defaultScale)
            {                
                StopCoroutine("btnScale");                
            }
            else           
            StartCoroutine("btnScale");

        }
        else
        {
            StartCoroutine("btnScale");
        }
    }    
}
