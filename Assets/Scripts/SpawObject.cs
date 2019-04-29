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
    public float tempoSpaw;     //  Tempo para instanciar um cano  na cena

    public float velocidadeMoedaAmarela;
    public float velocidadeMoedaAzul;
    public float velocidadeMoedaRoxa;

    public float tempoSpawMoedas;   //   Tempo para instaciar uma moeda na cena
    public float distanciaMoedasX; //
    public float distanciaMoedasY;// 
    
    //variáveis acumuladoras de tempo para o Spaw de objetos na cena
    private float RateSpawCanos;   
    private float RateSpawMoedas;

    public bool ligarGeradorDeCanos;
    public bool ligarGeradorDeMoedas;
    public bool ligarGeradorDeObstáculos;

    public GameObject prefabCanoVerde;  
    public GameObject prefabCanoAzul;   
    public GameObject prefabCanoRoxo;   

    public GameObject prefabMoedaAmarela; 
    public GameObject prefabMoedaAzul; 
    public GameObject prefabMoedaRocha;

    public int tamanhoDosObstaculos;

    public  List<GameObject> obstaculos;
    private List<GameObject> canosVerdes    = new List<GameObject>();
    private List<GameObject> canosAzuis     = new List<GameObject>();
    private List<GameObject> canosRoxos     = new List<GameObject>();

    private List<GameObject> moedasAmarelas = new List<GameObject>();
    private List<GameObject> moedasAzuis    = new List<GameObject>();
    private List<GameObject> moedasRoxas    = new List<GameObject>();

    void Start()
    {
        InstanceSpawObjetc = this;
        if (ligarGeradorDeCanos == true)
        {
            for (int i = 0; i < quantidade_de_objetos; i++) //guardando os canos clones na lista
            {
                //Instanciando todos os clones dos canos
                GameObject tempCano = Instantiate(prefabCanoAzul) as GameObject;
                canosAzuis.Add(tempCano);
                tempCano.SetActive(false);

                tempCano = Instantiate(prefabCanoVerde) as GameObject;
                canosVerdes.Add(tempCano);
                tempCano.SetActive(false);

                tempCano = Instantiate(prefabCanoRoxo) as GameObject;
                canosRoxos.Add(tempCano);
                tempCano.SetActive(false);


                //Instanciando todos os clones das moedas
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
        
        //Guardando as intancias dos objetos dos obstáculos inseridos na lista
        for (int i = 0; i < tamanhoDosObstaculos; i++)
        {
            GameObject obstaculo = Instantiate(obstaculos[i]) as GameObject;
            obstaculos.Add(obstaculo);
            obstaculo.SetActive(false);
        }
         
    }

    
    void Update()
    {
        Alle.InstanceAlle.setImunidadeTempo(tempoDanoHeroi); //tempo de dano do herói atualizado a cada FPS
        geradorCanos();
        gerarObstaculos();
    }

    private void geradorCanos( ) //instancia os objetos na tala
    {
        if (ligarGeradorDeCanos == true)
        {
            RateSpawCanos += Time.deltaTime; //tempo para contagem para gerar os Objetos
            if (GameControl.InstanceGameControl.isGameOver)
            {
                GameControl.InstanceGameControl.Die();
            }
            else
            {
                float randCanoPosition = Random.Range(alturaMinimaCano, alturaMaximaCano); //Randonizando as posicoes aleatoria dos canos

                if (RateSpawCanos > tempoSpaw)
                {
                    gerarCanos(randCanoPosition);
                    RateSpawCanos = 0; //Zera o tempo para uma nova contagem
                }
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

    private void gerarObstaculos()
    {
        RateSpawCanos += Time.deltaTime;
        if (ligarGeradorDeObstáculos == true)
        {
            if (RateSpawCanos > tempoSpaw)
            {
                GameObject obstaculo = null;
                for (int i = 0  ; i < obstaculos.Capacity ; i++ )
                {
                    if (obstaculos[i].activeSelf == false)
                    {
                        obstaculo = obstaculos[i];
                        break;
                    }
                }

                if (obstaculo != null)
                {
                    obstaculo.transform.position = new Vector3(transform.position.x, transform.position.y, 70);
                    obstaculo.SetActive(true);
                }
                RateSpawCanos = 0;
            }
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

        if (tempMoeda != null && ligarGeradorDeMoedas == true)
        {
            tempMoeda.transform.position = new Vector3(posicaoX, posicaoY,transform.position.z); //Define a posição onde as moedas serão instanciadas
            tempMoeda.SetActive(true);
        }

    }
}
