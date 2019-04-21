using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Gerenciador de Cenas da Unity
using UnityEngine.UI; //Gerenciador de texto da UI Unity

public class GameControl : MonoBehaviour
{
    public static GameControl Instance;
    private float instanceTime;
    public float scrollSpeed = -1.5f;
    public bool isGameOver = false;
    private int score = 0;
    private int bonus = 0;

    public Text scoreText;
    public Text bonusText;

    public GameObject gameOverText;

    void Awake() //acontece uma vez só
    {
        if (Instance == null) //Instancia do controlador
        {
            Instance = this;
        }
        else if( Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
       instanceTime += Time.deltaTime;
       if (instanceTime > 11f)
       {
            if (isGameOver && Input.GetButtonDown("Jump"))// controle do teclado
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Se o jogo acabar, a cena será recarregada no jogo
            }

            if (isGameOver && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)//toque
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
          
    }

    public void scoreFunction()
    {
        if (isGameOver)
        {
            return;
        }
        score++;
        scoreText.text = "Score: "+score;
    }

    public void bonusFunction() //passar uma tag como parâmetro para identificar o tipo de moeda
    {
        if (isGameOver)
        {
            return;
        }
        //moeda amarela +1,  azul +2, rocha +4
        bonus++;
        bonusText.text = "Moedas: " + bonus;
        //scoreText.text = "Score: " + score;
    }

    public void Die() //Se o jogo acabar, o texto Game Over aparece na tela
    {
        //animaçao de explosão
        isGameOver = true;
        gameOverText.SetActive(true);
    }
}
