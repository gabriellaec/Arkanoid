using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_velocidade : MonoBehaviour
{

   Text textComp;
   GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
       textComp = GetComponent<Text>();
       gm = GameManager.GetInstance();
   }

    // Update is called once per frame
    void Update()
    {
        textComp.text = $"Velocidade: {gm.speed-5}";

        if( gm.gameState == GameManager.GameState.MENU) textComp.GetComponent<Text>().color = Color.black;
        else textComp.GetComponent<Text>().color = Color.white;
    }
}
