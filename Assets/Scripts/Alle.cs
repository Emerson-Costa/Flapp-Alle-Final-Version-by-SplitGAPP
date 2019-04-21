using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alle : MonoBehaviour
{
    public float tapForce = 200;
    public Transform fumaca;
    public Transform defeito;
    public Transform nave;
    public int life;
    private Rigidbody2D rigdbody;
    private Animator fumacaDisco, aleAssustado;
    public float imunidade_tempo; //1.73
    public float poseInicial;
    private float tempo, tempoDestroyNave;
    private bool encostou = false;
    private Coracoes coracoes;


    
    void Start()
    {
        coracoes     = GameObject.FindObjectOfType<Coracoes>();
        rigdbody     = GetComponent<Rigidbody2D>(); //instanciando um componente
        fumacaDisco  = fumaca.GetComponent<Animator>();
        aleAssustado = GetComponent<Animator>();
    }

    
    void Update()
    {

        controleVida();
        movimentar(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);
        imunidade_de_tempo(poseInicial, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);
       
    }

    public void controleVida()//metodo vai precisar de um tempo para gerar explosao
    {
        if (life == 0)
        {//comando para cortar o método update quando o personagem morre.
            GetComponent<CapsuleCollider2D>().isTrigger = true;
            tempoDestroyNave += Time.deltaTime;
            nave.GetComponent<Animator>().SetBool("explodiu",true);
            if (tempoDestroyNave > 0.4F)
            {
                rigdbody.velocity = Vector2.zero;
                aleAssustado.SetTrigger("aleCaindo");
                nave.GetComponent<Animator>().SetBool("explodiu",false);
                Destroy(nave.gameObject);
                Destroy(this);
                tempoDestroyNave = 0;
            }
            GameControl.Instance.Die();
        }
    }

    public void imunidade_de_tempo(float x, float y, float z) //Método para deixar o personagem imune as colisões por um minuto determino
    {
        tempo += Time.deltaTime;
        if (encostou)
        {
            GetComponent<CapsuleCollider2D>().isTrigger = true;
            aleAssustado.SetBool("assustou", true);

            if (life != 0)
            {
              defeito.GetComponent<Animator>().SetBool("comDefeito", true);
            }
            
            GetComponent<Transform>().SetPositionAndRotation(new Vector3(poseInicial, y, z), Quaternion.identity); //mantem alinhado a posição do objeto na tela
        }


        if (tempo > imunidade_tempo)
        {
            encostou = false;
            GetComponent<CapsuleCollider2D>().isTrigger = false;

            if (life != 0)
            {
              defeito.GetComponent<Animator>().SetBool("comDefeito", false);
            }
           
            aleAssustado.SetBool("assustou", false);
            tempo = 0;
            GetComponent<Transform>().SetPositionAndRotation(new Vector3(poseInicial, y, z), Quaternion.identity); //mantem alinhado a posição do objeto na tela
        }
    }

    public void movimentar(float x, float y, float z)
    {
        /***************************************************controle para o PC********************************************************/ 
        if (Input.GetButtonDown("Jump") && GetComponent<Transform>().position.y < 4.88f) //Limite superior de movimento do personagem
        {
            rigdbody.velocity = Vector2.zero;
            rigdbody.AddForce( new Vector2(0,tapForce));
            fumacaDisco.SetBool("temFumaca",true);
        }
        else
        {
            fumacaDisco.SetBool("temFumaca", false);
        }
        /******************************************************************************************************************************/

        /************************************************* controle para mobile*******************************************************/
        if (Input.touchCount > 0)
        {
            print(Input.touchCount);
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && GetComponent<Transform>().position.y < 4.88f)
        {
            rigdbody.velocity = Vector2.zero;
            rigdbody.AddForce(new Vector2(0, tapForce));
            fumacaDisco.SetBool("temFumaca", true);
        }
        /*****************************************************************************************************************************/


        if (GetComponent<Transform>().position.y < -4.14f) //limite inferior da tela
        {
            rigdbody.velocity = Vector2.zero;
            rigdbody.AddForce(new Vector2(0, 150));

            if (GetComponent<Transform>().position.y > 4.88f)//limite para a parte superior da tela para o personagem não escapar da cena
            {
                rigdbody.velocity = Vector2.zero;
            }
        }
        
    }

    public void OnCollisionEnter2D(Collision2D collision)//Usada sempre quando o objeto colide com o outro objeto
    {
        if (life > 0 && collision.gameObject.tag == "canoAzul"  ||
            life > 0 && collision.gameObject.tag == "canoRocho" || 
            life > 0 && collision.gameObject.tag == "canoVerde" ||
            life > 0 && collision.gameObject.tag == "chao"        ){

            encostou = true;
            life--;
            coracoes.cambioVida(life);
            GetComponent<Transform>().SetPositionAndRotation(new Vector3(poseInicial, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z), Quaternion.identity); //mantem alinhado a posição do objeto na tela

        }
    }
}
