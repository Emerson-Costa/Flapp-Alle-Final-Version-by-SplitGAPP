using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cano : MonoBehaviour
{
    public static Cano InstanceCano;

    private float velocidadeCanoAzul;
    private float velocidadeCanoVerde;
    private float velocidadeCanoRoxo;

    void Start()
    {
        InstanceCano = this; 
    }

    void Update()
    {
        if (GameControl.InstanceGameControl.isGameOver)
        {
            GameControl.InstanceGameControl.Die();
        }
        else
        {
            if (SpawObject.InstanceSpawObjetc.escolherCano == 1) //Cano Azul
            {
                transform.Translate(Vector2.right * SpawObject.InstanceSpawObjetc.velocidadeCanoAzul * Time.deltaTime);
               
            }

            if (SpawObject.InstanceSpawObjetc.escolherCano == 2) //Cano Verde
            {
                transform.Translate(Vector2.right * SpawObject.InstanceSpawObjetc.velocidadeCanoVerde * Time.deltaTime);
                
            }

            if (SpawObject.InstanceSpawObjetc.escolherCano == 3) //Cano Roxo
            {
                transform.Translate(Vector2.right * SpawObject.InstanceSpawObjetc.velocidadeCanoRoxo * Time.deltaTime);
               
            }
        }    

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Destruir")
        {
            gameObject.SetActive(false);
        }
    }

    //encapsulamento
    /*public void setVelocidadeCanoAzul(float velocidade)
    {
        this.velocidadeCanoAzul = velocidade;
    }*/

    public void setVelocidadeCanoVerde(float velocidade)
    {
        this.velocidadeCanoVerde = velocidade;
    }

    public void setVelocidadeCanoRoxo(float velocidade)
    {
        this.velocidadeCanoRoxo = velocidade;
    }

}
