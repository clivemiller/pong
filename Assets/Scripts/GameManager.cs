using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
   public Ball ball;
   public Paddle player1;
   public Paddle player2;

   [SerializeField] private PauseScreen pauseScreen;

   public static Vector2 BottomLeft;
   public static Vector2 TopRight;

   private bool _isPaused = false;

   void Start()
   {
      BottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
      TopRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

      if (pauseScreen == null)
      {
         pauseScreen = FindFirstObjectByType<PauseScreen>();
      }
   }

   void Update() {
      if (Keyboard.current == null)
      {
         return;
      }

      if (Keyboard.current.escapeKey.isPressed)
      {
         Application.Quit();
      }

      if (Keyboard.current.tabKey.wasPressedThisFrame)
      {
         _isPaused = !_isPaused;
         if (_isPaused) 
         {
            pauseScreen.PauseGame();
         }
         else
         {
            pauseScreen.ResumeGame();
         }
      }
      
      if (Keyboard.current.iKey.isPressed)
      {
         player1.MoveUp();
      }

      if (Keyboard.current.kKey.isPressed)
      {
         player1.MoveDown();
      }

      if (Keyboard.current.wKey.isPressed)
      {
         player2.MoveUp();
      }

      if (Keyboard.current.sKey.isPressed)
      {
         player2.MoveDown();
      }
   }

}
