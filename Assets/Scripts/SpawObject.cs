using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawObject : MonoBehaviour
{
    public static SpawObject InstanceSpawObjetc;

    public int escolherCano;   //1- Cano Azul, 2- Cano Verde, 3- Cano Roxo, 4- Todos os canos.
    public int escolherMoedas;// 1- Moedas Amarelas, 2- Moedas Azuis, 3- Moedas Roxas, 4- Todas as moedas. 
    public int quantidade_de_objetos; //quantidade de objetos a serem instanciados na cena.

    public float poseInicialHeroi;          //-9,5
    public float tempoDanoHeroi;
    public float alturaMaximaCano;         //Altura máxima
    public float alturaMinimaCano;        // Altura mínima
    public float velocidadeCanoVerde;
    public float velocidadeCanoAzul;
    public float velocidadeCanoRoxo;
    public float tempoSpawCanos;     //  Tempo para instanciar um cano  na cena

    public float velocidadeMoedas;
    public float tempoSpawMoedas;   //   Tempo para instaciar uma moeda na cena
    public float distanciaMoedasX; //
    public float distanciaMoedasY;// 
    
    //variáveis acumuladoras de tempo para o Spaw de objetos na cena
    private float RateSpawCanos;   
    private float RateSpawMoedas;

    public bool ligarRandCanos;
    public bool ligarRandMoedas;

    public GameObject prefabCanoVerde;  
    public GameObject prefabCanoAzul;   
    public GameObject prefabCanoRoxo;   

    public GameObject prefabMoedaAmarela; 
    public GameObject prefabMoedaAzul; 
    public GameObject prefabMoedaRocha; 

    private List<GameObject> canosVerdes    = new List<GameObject>();
    private List<GameObject> canosAzuis     = new List<GameObject>();
    private List<GameObject> canosRoxos     = new List<GameObject>();

    private List<GameObject> moedasAmarelas = new List<GameObject>();
    private List<GameObject> moedasAzuis    = new List<GameObject>();
    private List<GameObject> moedasRoxas    = new List<GameObject>();

    void Start()
    {
        InstanceSpawObjetc = this;
        for (int i=0;  i < quantidade_de_objetos ; i++) //guardando os objetos na lista, a quantidade de canos é igual a quantidade de moedas
        {
            //Instanciando todos os canos
            GameObject tempCano = Instantiate(prefabCanoAzul) as GameObject;
            canosAzuis.Add(tempCano);
            tempCano.SetActive(false);

            tempCano = Instantiate(prefabCanoVerde) as GameObject;
            canosVerdes.Add(tempCano);
            tempCano.SetActive(false);

            tempCano = Instantiate(prefabCanoRoxo) as GameObject;
            canosRoxos.Add(tempCano);
            tempCano.SetActive(false);

          
            //Instanciando todas as moedas
            GameObject tempMoeda = Instantiate(prefabMoedaAmarela) as GameObject;
            moedasAmarelas.Add(tempMoeda);
            tempMoeda.SetActive(false);

            tempMoeda = Instantiate(prefabMoedaAzul) as GameObject;
            moedasAzuis.Add(tempMoeda);
            tempMoeda.SetActive(false);

            tempMoeda = Instantiate(prefabMoedaRocha) as GameObject;
            moedasRoxas.Add(tempMoeda);
            tempMoeda.SetActive(false);
        }  
    }

    
    void Update()
    {
        Alle.InstanceAlle.setImunidadeTempo(tempoDanoHeroi); //tempo de dano do herói atualizado a cada FPS
        fasesMundo01();
    }

    private void fasesMundo01( ) //instancia os objetos na tala
    {
        RateSpawCanos += Time.deltaTime; //tempo para contagem para gerar os Objetos
        if (GameControl.InstanceGameControl.isGameOver)
        {
            GameControl.InstanceGameControl.Die();
        }
        else
        {
            float randCanoPosition = Random.Range(alturaMinimaCano, alturaMaximaCano); //Randonizando as posicoes aleatoria dos canos

            if (RateSpawCanos > tempoSpawCanos  && ligarRandCanos == true )
            {  
                gerarCanos(randCanoPosition);
                RateSpawCanos = 0; //Zera o tempo para uma nova contagem
            }
        }
    }

    private void gerarCanos(float randPosition)
    {
        GameObject tempCano = null;

        if (escolherCano == 1)//Cano Azul
        {
            for (int i = 0; i < quantidade_de_objetos; i++)
            {
                if (canosAzuis[i].activeSelf == false)
                {
                    tempCano = canosAzuis[i];
                    break;
                }
            }
        }

        
        if (escolherCano == 2)//Cano Verde
        {
            for (int i = 0; i < quantidade_de_objetos; i++)
            {
                if (canosVerdes[i].activeSelf == false)
                {
                    tempCano = canosVerdes[i];
                    break;
                }
            }
        }

       
        if (escolherCano == 3)//Cano Roxo
        {
            for (int i = 0; i < quantidade_de_objetos; i++)
            {
                if (canosRoxos[i].activeSelf == false)
                {
                    tempCano = canosRoxos[i];
                    break;
                }
            }
        }

        if (tempCano != null)
        {
            tempCano.transform.position = new Vector3(transform.position.x, randPosition, transform.position.z);
            tempCano.SetActive(true);
        }

    }

    private void gerarMoedas(float posicaoX, float posicaoY) 
    {
        GameObject tempMoeda = null;

        if (escolherMoedas == 1)//Moeda Amarela
        {

            for (int i = 0; i < quantidade_de_objetos; i++)
            {
                if (moedasAmarelas[i].activeSelf == false)
                {
                    tempMoeda = moedasAmarelas[i];
                    break;
                }
            }
        }

        if (escolherMoedas == 2)//Moeda Azul
        {
            for (int i = 0; i < quantidade_de_objetos; i++)
            {
                if (moedasAzuis[i].activeSelf == false)
                {
                    tempMoeda = moedasAzuis[i];
                    break;
                }
            }
        }

        if (escolherMoedas == 3)//Moeda Roxa
        {
            for (int i = 0; i < quantidade_de_objetos; i++)
            {
                if (moedasRoxas[i].activeSelf == false)
                {
                    tempMoeda = moedasRoxas[i];
                    break;
                }
            }
        }

        if (tempMoeda != null && ligarRandMoedas == true)
        {
            tempMoeda.transform.position = new Vector3(posicaoX, posicaoY,transform.position.z); //Define a posição onde as moedas serão instanciadas
            tempMoeda.SetActive(true);
        }

    }
}
