using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moedas : MonoBehaviour
{
    public static Moedas IntanceMoedas;

    public Transform moedaAmarela;
    public Transform moedaAzul;
    public Transform moedaRoxa;

    private float velocidadeMoedaAmarela;
    private float velocidadeMoedaAzul;
    private float velocidadeMoedaRoxa;

    private float tempo;


    void Start()
    {
        IntanceMoedas = this;
        
    }

    public void Update()
    {
        velocidadeMoedaAmarela = SpawObject.InstanceSpawObjetc.velocidadeMoedaAmarela;
        velocidadeMoedaAzul    = SpawObject.InstanceSpawObjetc.velocidadeMoedaAzul;
        velocidadeMoedaRoxa    = SpawObject.InstanceSpawObjetc.velocidadeMoedaRoxa;

        if (GameControl.InstanceGameControl.isGameOver)
        {
            GameControl.InstanceGameControl.Die();
        }
        else{

            moedaAmarela.transform.Translate(Vector2.right * velocidadeMoedaAmarela  * Time.deltaTime);
          
            moedaAzul.transform.Translate(Vector2.right    * velocidadeMoedaAzul     * Time.deltaTime);
           
            moedaRoxa.transform.Translate(Vector2.right    * velocidadeMoedaRoxa     * Time.deltaTime);  
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
