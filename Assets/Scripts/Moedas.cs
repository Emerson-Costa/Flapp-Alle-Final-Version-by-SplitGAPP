using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moedas : MonoBehaviour
{
    public float velocidade;
    private float tempo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Alle>() != null) //Se o objeto Alle não colidir com a pilastra outro método é chamado
        {
           // GetComponent<Animator>().SetBool("pegouMoeda", true);
            GameControl.Instance.bonusFunction(); //Chamou o metodo de pomtuação
            gameObject.SetActive(false);
        }
    }

    public void Update()
    {  
        if (GameControl.Instance.isGameOver)
        {
            GameControl.Instance.Die();
        }
        else{
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
        }
    }
}
