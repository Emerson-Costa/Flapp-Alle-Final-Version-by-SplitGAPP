using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawObject : MonoBehaviour
{
    public static SpawObject InstanceSpawObjetc;

    public float maxHeigth;  //Altura máxima
    public float minHeigth; //Altura mínima
    public float rateSpaw; //Tempo exato para instanciar um objeto na tela
    public int escolherCano;   //1- Cano Azul, 2- Cano Verde, 3- Cano Roxo, 4- Todos os canos
    public int escolherMoedas;// 1- Moedas Amarelas, 2- Moedas Azuis, 3- Moedas Roxas, 4- Todas as moedas 
    private float currentRateSpaw;/*Esta variável é ativada quando for tratar do acumulo da contagem do o tempo para instanciar um determinado objeto na cena em tempo real de execução*/

    public int quantidade_de_objetos; //quantidade de objetos a serem instanciados no jogo.

    public GameObject prefabCanoVerde;  //Objeto Cano verde
    public GameObject prefabCanoAzul;   //Objeto Cano azul
    public GameObject prefabCanoRoxo;   //Objeto Cano roxo

    public GameObject prefabMoedaAmarela; //Objeto moeda
    public GameObject prefabMoedaAzul; //Objeto moeda
    public GameObject prefabMoedaRocha; //Objeto moeda

    public List<GameObject> canosVerdes; //Lista para armazenar os canos verdes
    public List<GameObject> canosAzuis;  //Lista para armazenar os canos azuis
    public List<GameObject> canosRoxos;  //Lista para armazenar os canos roxos

    public List<GameObject> moedasAmarelas; //Lista para armazenar as moedas amarelas
    public List<GameObject> moedasAzuis; //Lista para armazenar as moedas azuis 
    public List<GameObject> moedasRoxas; //Lista para armazenar as moedas roxas

   
        
   

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
        fasesMundo01();
    }

    private void fasesMundo01() //instancia os objetos na tala
    {
        currentRateSpaw += Time.deltaTime; //tempo para contagem para gerar os Objetos
        if (GameControl.Instance.isGameOver)
        {
            GameControl.Instance.Die();
        }
        else
        {
            if (currentRateSpaw > rateSpaw)
            {
                /*****************Trecho onde serão decididas as jogabilidades da fase*****************************/
                float randPosition = Random.Range(minHeigth, maxHeigth); //Gera Posições aleatórias na tela do jogo
                gerarCanos(randPosition);
                gerarMoeda(randPosition);
                /*************************************************************************************************/

                currentRateSpaw = 0; //Zera o tempo para uma nova contagem
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

    private void gerarMoeda(float randPosition) 
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

        if (tempMoeda != null)
        {
            tempMoeda.transform.position = new Vector3(transform.position.x + 5, randPosition - 2.5f, transform.position.z); //Define a posição onde as moedas serão instanciadas
            tempMoeda.SetActive(true);
        }

    }

}
