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

       if(gm.vidas > 0 && gm.timeRemainig >=0){
           message.text = "Você Ganhou!!";
           gm.pontos += (int)(gm.timeRemainig*5);
       } 
       else if (gm.vidas > 0 && gm.timeRemainig <= 0) message.text = "Timeout!!";
       else message.text = "Você Perdeu!!";

       // highscore
        if ( (PlayerPrefs.GetInt("HighScore",0)) < gm.pontos) 
            PlayerPrefs.SetInt("HighScore", gm.pontos);

       recorde = PlayerPrefs.GetInt("HighScore",0);
       if (recorde == gm.pontos) score.text = "New High Score!!";
       else score.text = $"Score: {gm.pontos}";

       
       highscore.text = $"HighScore: {recorde.ToString()}";
   }


   
    public void Voltar()
    {
        gm.level=1;
        gm.ChangeState(GameManager.GameState.GAME);
    }

}