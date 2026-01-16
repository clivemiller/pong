using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
   public string pauseText;
   public void ResumeGame()
   {
      Time.timeScale = 1f;
      HandleShowText(false);
   }

   public void PauseGame()
   {
      Time.timeScale = 0f;
      HandleShowText(true);
   }

   private void HandleShowText(bool show)
   {
      GetComponent<TMP_Text>().text = show ? pauseText : "Press Tab to Pause";
   }
}
