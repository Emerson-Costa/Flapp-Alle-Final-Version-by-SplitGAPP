using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOffset : MonoBehaviour
{
    private Material currentMaterial;
    public float speed;
    private float offset;

    void Start()
    {
        currentMaterial = GetComponent<Renderer>().material;
    }

    
    void Update()
    {
        offset += 0.001f;

        if (!GameControl.Instance.isGameOver)
        {
          currentMaterial.SetTextureOffset("_MainTex", new Vector2(offset * speed, 0));
        }
        
    }
}
