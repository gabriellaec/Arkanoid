using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_FimDeJogo : MonoBehaviour
{
   public Text message;

    GameManager gm;
   private void OnEnable()
   {
       gm = GameManager.GetInstance();

       if(gm.vidas > 0)
       {
           message.text = "Você Ganhou!!!";
       }
       else
       {
           message.text = "Você Perdeu!!";
       }
   }


   
    public void Voltar()
    {
        gm.level=1;
        gm.ChangeState(GameManager.GameState.GAME);
    }

}