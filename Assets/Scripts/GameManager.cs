using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
   public Ball ball;
   public Paddle player1;
   public Paddle player2;

   public static Vector2 BottomLeft;
   public static Vector2 TopRight;

   void Start()
   {
      BottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
      TopRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
   }

   void Update() {
      if (Keyboard.current.escapeKey.isPressed)
      {
         Application.Quit();
      }

      if (Keyboard.current.tabKey.isPressed)
      {
         // pause
      }
      
      if (Keyboard.current.wKey.isPressed)
      {
         player1.MoveUp();
      }

      if (Keyboard.current.sKey.isPressed)
      {
         player1.MoveDown();
      }

      if (Keyboard.current.iKey.isPressed)
      {
         player2.MoveUp();
      }

      if (Keyboard.current.kKey.isPressed)
      {
         player2.MoveDown();
      }
   }

}
