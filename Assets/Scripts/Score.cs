using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
   public string player1ScoreText;
   public string player2ScoreText;

   private GameManager _gameManager;

   private void Awake()
   {
      _gameManager = FindAnyObjectByType<GameManager>();
   }

   private void Update()
   {
      if (_gameManager != null)
      {
         player1ScoreText = _gameManager.player1.score.ToString();
         player2ScoreText = _gameManager.player2.score.ToString();
      }
      GetComponent<TMP_Text>().text = "Player 1: " + player1ScoreText + " - Player 2: " + player2ScoreText;
      if (_gameManager.player1.score >= 3)
      {
         GetComponent<TMP_Text>().text = "Player 1 WINS!";
         Time.timeScale = 0f;
      }
      else if (_gameManager.player2.score >= 3)
      {
         GetComponent<TMP_Text>().text = "Player 2 WINS!";
         Time.timeScale = 0f;
      }
   }
}
