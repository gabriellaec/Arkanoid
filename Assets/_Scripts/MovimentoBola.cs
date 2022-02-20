using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoBola : MonoBehaviour
{
   public float velocidade;
   private Vector3 direcao;
   GameManager gm;
    // Start is called before the first frame update
   void Start()
   {
       float dirX = Random.Range(-5.0f, 5.0f);
       float dirY = Random.Range(2.0f, 5.0f);

       direcao = new Vector3(dirX, dirY).normalized;
       velocidade = 6;
       gm = GameManager.GetInstance();
    }

   // Update is called once per frame
   void Update()
   {
       if(Input.GetKeyDown(KeyCode.UpArrow) && gm.gameState == GameManager.GameState.GAME) 
         velocidade++;

        if(Input.GetKeyDown(KeyCode.DownArrow) && gm.gameState == GameManager.GameState.GAME && velocidade >=6) 
         velocidade--;
        

       if (gm.gameState != GameManager.GameState.GAME) return;

       transform.position += direcao * Time.deltaTime * velocidade;

       Vector2 posicaoVP = Camera.main.WorldToViewportPoint(transform.position);

       if(posicaoVP.x < 0 || posicaoVP.x > 1)
       {
           direcao = new Vector3(-direcao.x, direcao.y);
       }
       if(posicaoVP.y > 1)
       {
           direcao = new Vector3(direcao.x, -direcao.y);
       }
       if(posicaoVP.y < 0)
       {
           Reset();
       }

       if (gm.levelchange){
           Reset();
           gm.levelchange = false;
       }
       
        Debug.Log($"Vidas: {gm.vidas} \t | \t Pontos: {gm.pontos}");

        if( gm.gameState == GameManager.GameState.GAME && gm.timeRemainig <= 0)
        {
        gm.ChangeState(GameManager.GameState.ENDGAME);
        } 
    }

    private void Reset()
   {
       velocidade = 6;
       Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
       transform.position = playerPosition + new Vector3(0, 0.5f, 0);

       float dirX = Random.Range(-5.0f, 5.0f);
       float dirY = Random.Range(2.0f, 5.0f);

       direcao = new Vector3(dirX, dirY).normalized;
       gm.vidas--;

       if( gm.gameState == GameManager.GameState.GAME && gm.vidas <= 0)
        {
        gm.ChangeState(GameManager.GameState.ENDGAME);
        } 
   }

   private void OnTriggerEnter2D(Collider2D collision)
   {
       if (collision.gameObject.CompareTag("Player"))
       {
           float dirX = Random.Range(-5.0f, 5.0f);
           float dirY = Random.Range(1.0f, 5.0f);
           direcao = new Vector3(dirX, dirY).normalized;
       }
       else if (collision.gameObject.CompareTag("Tijolo"))
       {
           direcao = new Vector3(direcao.x, -direcao.y);
           gm.pontos++;
        }
   }

}