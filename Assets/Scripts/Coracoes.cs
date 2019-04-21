using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Coracoes : MonoBehaviour
{

    public Sprite[] coracoes;
   
    // Start is called before the first frame update
    void Start()
    { 
        cambioVida(3); //inicializa com o três coracoes 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cambioVida(int pos)
    {
        this.GetComponent<Image>().sprite = coracoes[pos];
    }
}
