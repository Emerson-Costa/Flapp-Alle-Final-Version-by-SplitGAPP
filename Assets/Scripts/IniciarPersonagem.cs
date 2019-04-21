using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciarPersonagem : MonoBehaviour
{
    public GameObject personagem;
    float temp;

    void Start()
    {
        personagem = Instantiate(personagem) as GameObject;
    }

   
    void Update()
    {
        
    }

    public void escolha()
    {
        //aqui será o código para a escolha do herói do jogo
    }

}
