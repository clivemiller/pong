using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
   public void ResumeGame()
   {
      Time.timeScale = 1f;
      gameObject.SetActive(false);
      HandleShowText(false);
   }

   public void PauseGame()
   {
      Time.timeScale = 0f;
      gameObject.SetActive(true);
      HandleShowText(true);
   }

   private void HandleShowText(bool show)
   {
      GetComponent<TMP_Text>().enabled = show;
   }
}
