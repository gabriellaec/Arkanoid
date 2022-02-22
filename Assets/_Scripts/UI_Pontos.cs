using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Pontos : MonoBehaviour
{
   Text textComp;
   GameManager gm;
   void Start()
   {
       textComp = GetComponent<Text>();
       gm = GameManager.GetInstance();
   }
   
   void Update()
   {
       textComp.text = $"Pontos: {gm.pontos}";

    if( gm.gameState == GameManager.GameState.MENU) textComp.GetComponent<Text>().color = Color.black;
    else textComp.GetComponent<Text>().color = Color.white;
       
   }
}