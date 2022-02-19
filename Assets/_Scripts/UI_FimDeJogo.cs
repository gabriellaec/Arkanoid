using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_FimDeJogo : MonoBehaviour
{
   public Text message;
   public Text score;
   public Text highscore;
   public int recorde;

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

       score.text = $"Score: {gm.pontos}";

       recorde = PlayerPrefs.GetInt("HighScore",0);
       highscore.text = $"HighScore: {recorde.ToString()}";
   }


   
    public void Voltar()
    {
        gm.level=1;
        gm.ChangeState(GameManager.GameState.GAME);
    }

}