using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moedas : MonoBehaviour
{
    public static Moedas IntanceMoedas;

    private float velocidade;
    private float tempo;


    void Start()
    {
        IntanceMoedas = this;
        
    }

    public void Update()
    {
        velocidade = SpawObject.InstanceSpawObjetc.velocidadeMoedas;
        if (GameControl.InstanceGameControl.isGameOver)
        {
            GameControl.InstanceGameControl.Die();
        }
        else{
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Alle>() != null) //Se o objeto Alle não colidir com a pilastra outro método é chamado
        {
            GameControl.InstanceGameControl.bonusFunction(); //Chamou o metodo de pomtuação
            gameObject.SetActive(false);
        }
    }
}
