using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_nivel : MonoBehaviour
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
       textComp.text = $"Nível: {gm.level}";

    if( gm.gameState == GameManager.GameState.MENU) textComp.GetComponent<Text>().color = Color.black;
    else textComp.GetComponent<Text>().color = Color.white;
       
   }
}