using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Coracoes : MonoBehaviour
{

    public Sprite[] coracoes;
   
    void Start()
    { 
        cambioVida(3); //inicializa com o três coracoes 
    }

    public void cambioVida(int pos)
    {
        this.GetComponent<Image>().sprite = coracoes[pos];
    }
}
