using UnityEngine;

public class Paddle : MonoBehaviour
{
      public float speed = 10f;
      public float top;
      public float bottom;

      private void Awake()
      {
         GetTopBottom(out top, out bottom);
      }

      public void GetTopBottom(out float top, out float bottom)
      {
          float halfHeight = GetComponent<SpriteRenderer>().bounds.size.y / 2;
          top = transform.position.y + halfHeight;
          bottom = transform.position.y - halfHeight;
      }

      public void MoveUp()
      {
         print("top: " + top + " GameManager.TopRight.y: " + GameManager.TopRight.y);
         if (top >= GameManager.TopRight.y)
         {
             return;
         }
         transform.Translate(Vector2.up * speed * Time.deltaTime);
      }
      public void MoveDown()
      {
         print("bottom: " + bottom + " GameManager.BottomLeft.y: " + GameManager.BottomLeft.y);
         if (bottom <= GameManager.BottomLeft.y)
         {
             return;
         }
         transform.Translate(Vector2.down * speed * Time.deltaTime);
      }

      public void UpdateTopBottom()
      {
         GetTopBottom(out top, out bottom);
      }

      private void Update()
      {
         UpdateTopBottom();
      }
}
