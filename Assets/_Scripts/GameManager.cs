using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager
{
   public enum GameState { MENU, GAME, PAUSE, ENDGAME };
   public GameState gameState { get; private set; }
   public int vidas;
   public int pontos;
   public int level;
   public int speed;
   private static GameManager _instance;

    public float timeRemainig;
    
    public bool superbola = false;
    public bool superUltraBola = false;

    public bool waspaused = false;


   public bool levelchange = false;



   public static GameManager GetInstance()
   {
       if(_instance == null)
       {
           _instance = new GameManager();
       }

       return _instance;
   }

   public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;

    public void ChangeState(GameState nextState)
    {
    if (nextState == GameState.GAME && (gameState != GameState.PAUSE )) Reset();

    else if (nextState == GameState.GAME && (gameState == GameState.PAUSE )) 
        waspaused = true;

    gameState = nextState;
    changeStateDelegate();
    }

    private void Reset()
    {
    vidas = 5;
    pontos = 0;
    timeRemainig = 420;
    }
   private GameManager()
   {
       vidas = 5;
       pontos = 0;
       gameState = GameState.MENU;
       level=1;
       timeRemainig = 420;
   }
}