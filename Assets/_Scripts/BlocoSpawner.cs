using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoSpawner : MonoBehaviour
{
  public GameObject Bloco;
  public GameObject GO;
  GameManager gm;


  void Start()
  {
      gm = GameManager.GetInstance();
      GameManager.changeStateDelegate += Construir;
      Construir();
  }

  void Construir()
  {
     

       if (gm.gameState == GameManager.GameState.GAME)
      {
          foreach (Transform child in transform) {
              GameObject.Destroy(child.gameObject);
          }
          for(int i = 0; i < 12; i++)
          {
              for(int j = 0; j < 7; j++){
                  Vector3 posicao = new Vector3(-9 + 1.55f * i, 4 - 0.55f * j);
                //   Instantiate(Bloco, posicao, Quaternion.identity, transform);


                  GO = Instantiate (Bloco, posicao, Quaternion.identity, transform) as GameObject ;
                  
                  var BlocoRenderer = GO.GetComponent<Renderer>();
                  if (j%3==0){     
                    
                    BlocoRenderer.material.color = new Color(232 , 0 , 254, 1); //pink
                    GO.GetComponent<Bloco>().kill_hits = 3;
                  } else if (j%2==0){
                    BlocoRenderer.material.color = new Color( 0 , 201 , 254, 1 );  //blue
                    GO.GetComponent<Bloco>().kill_hits = 2;
                  } else BlocoRenderer.material.color = new Color( 0 , 255 , 0, 1 );  //green

                  // https://answers.unity.com/questions/785696/global-list-of-colour-names-and-colour-values.html
                 
              }
          }
      }
  }

  void Update()
  {
      if (transform.childCount <= 0 && gm.gameState == GameManager.GameState.GAME)
      {
          gm.ChangeState(GameManager.GameState.ENDGAME);
      }

    //   else if (GO.hits==1) {
    //         if (GO.kill_hits == 3) // pink
    //         BlocoRenderer.material.color = new Color( 0 , 201 , 254, 1 );  //blue
    //         if (GO.kill_hits == 2) // blue
    //         BlocoRenderer.material.color = new Color(166, 254, 0 );  //green
    //     }

  }

}