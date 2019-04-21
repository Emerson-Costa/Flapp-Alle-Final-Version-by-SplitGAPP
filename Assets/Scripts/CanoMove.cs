using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanoMove : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameControl.Instance.isGameOver)
        {
            GameControl.Instance.Die();
        }
        else
        {
           if (SpawObject.InstanceSpawObjetc.escolherCano == 2)
           {
                transform.Translate(Vector2.right * -5f * Time.deltaTime);
           }
            
        }    
    }
}
