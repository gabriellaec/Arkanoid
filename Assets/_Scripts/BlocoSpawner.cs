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

  void Construir() {
    
       if (gm.gameState == GameManager.GameState.GAME) {
          foreach (Transform child in transform) {
              GameObject.Destroy(child.gameObject);
          }

          if (gm.level == 1){
            for(int i = 0; i < 12; i++) {
                for(int j = 0; j < 3; j++){
                    Vector3 posicao = new Vector3(-9 + 1.55f * i, 4 - 0.55f * j);
                    GO = Instantiate (Bloco, posicao, Quaternion.identity, transform) as GameObject ;
                    var BlocoRenderer = GO.GetComponent<Renderer>();
                    if (j%2==0){
                      BlocoRenderer.material.color = new Color( 0 , 201 , 254, 1 );  //blue
                      GO.GetComponent<Bloco>().kill_hits = 2;
                    } else BlocoRenderer.material.color = new Color( 0 , 255 , 0, 1 );  //green
                }
            }
          }else if (gm.level ==2){
            for(int i = 0; i < 12; i++) {
                for(int j = 0; j < 7; j++){
                    Vector3 posicao = new Vector3(-9 + 1.55f * i, 4 - 0.55f * j);
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
          }else {
            for(int i = 0; i < 12; i++) {
                for(int j = 0; j < 9; j++){
                    Vector3 posicao = new Vector3(-9 + 1.55f * i, 4 - 0.55f * j);
                    GO = Instantiate (Bloco, posicao, Quaternion.identity, transform) as GameObject ;
                    var BlocoRenderer = GO.GetComponent<Renderer>();
                    if (i%3==0){     
                      BlocoRenderer.material.color = new Color(232 , 0 , 254, 1); //pink
                      GO.GetComponent<Bloco>().kill_hits = 3;
                    } else if (i%2==0){
                      BlocoRenderer.material.color = new Color( 0 , 201 , 254, 1 );  //blue
                      GO.GetComponent<Bloco>().kill_hits = 2;
                    } else BlocoRenderer.material.color = new Color( 0 , 255 , 0, 1 );  //green
                }
            }
          }
      }
  }

  void Update()
  {
      if (transform.childCount <= 0 && gm.gameState == GameManager.GameState.GAME)
      {
          if (gm.level == 1){
            gm.level += 1;
            gm.pontos *= 2;
            Construir();
            gm.levelchange = true;
          }else if (gm.level == 2){
            gm.level += 1;
            gm.pontos *= 2;
            Construir();
            gm.levelchange = true;
          }
          else {
            gm.ChangeState(GameManager.GameState.ENDGAME);
            gm.level = 1;
          }   
      }
  }

}