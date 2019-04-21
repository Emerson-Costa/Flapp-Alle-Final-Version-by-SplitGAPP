using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Alle>() != null) //Se o objeto Alle não colidir com a pilastra outro método é chamado
        {
            GameControl.Instance.scoreFunction(); //Chamou o metodo de pomtuação
        }      
    }
}
