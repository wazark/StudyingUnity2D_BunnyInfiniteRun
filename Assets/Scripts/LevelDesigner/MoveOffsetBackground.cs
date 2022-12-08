using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOffsetBackground : MonoBehaviour
{
    private Renderer mRender;
    private Material currentMaterial;
    private float mOffset;

    public float offsetSpeed;
    public float incrementOffset;
    public string sortingLayer;
    public int orderInLayer;

    void Start()
    {
        mRender= GetComponent<Renderer>();

        currentMaterial = mRender.material;
        mRender.sortingLayerName = sortingLayer;
        mRender.sortingOrder = orderInLayer;
    }

    
    void FixedUpdate()
    {
        mOffset += incrementOffset;
        currentMaterial.SetTextureOffset("_MainTex", new Vector2(mOffset * offsetSpeed, 0));
        
    }
}
