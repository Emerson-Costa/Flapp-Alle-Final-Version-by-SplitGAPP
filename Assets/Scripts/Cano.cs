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
                Moedas.IntanceMoedas.setVelocidade(SpawObject.InstanceSpawObjetc.velocidadeCanoAzul);
            }

            if (SpawObject.InstanceSpawObjetc.escolherCano == 2) //Cano Verde
            {
                transform.Translate(Vector2.right * SpawObject.InstanceSpawObjetc.velocidadeCanoVerde * Time.deltaTime);
                Moedas.IntanceMoedas.setVelocidade(SpawObject.InstanceSpawObjetc.velocidadeCanoVerde);
            }

            if (SpawObject.InstanceSpawObjetc.escolherCano == 3) //Cano Roxo
            {
                transform.Translate(Vector2.right * SpawObject.InstanceSpawObjetc.velocidadeCanoRoxo * Time.deltaTime);
                Moedas.IntanceMoedas.setVelocidade(SpawObject.InstanceSpawObjetc.velocidadeCanoRoxo);
            }
        }    
    }

    //encapsulamento
    public void setVelocidadeCanoAzul(float velocidade)
    {
        this.velocidadeCanoAzul = velocidade;
    }

    public void setVelocidadeCanoVerde(float velocidade)
    {
        this.velocidadeCanoVerde = velocidade;
    }

    public void setVelocidadeCanoRoxo(float velocidade)
    {
        this.velocidadeCanoRoxo = velocidade;
    }

}
