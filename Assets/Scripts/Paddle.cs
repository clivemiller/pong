using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Paddle : MonoBehaviour
{
      public float speed = 25f;
      public float top;
      public float bottom;

      private SpriteRenderer _spriteRenderer;
      private float _halfHeight;

      private void Awake()
      {
         _spriteRenderer = GetComponent<SpriteRenderer>();
         UpdateTopBottom();
      }

      public void GetTopBottom(out float top, out float bottom)
      {
         UpdateTopBottom();
         top = this.top;
         bottom = this.bottom;
      }

      public void MoveUp()
      {
         UpdateTopBottom();

         float maxY = GameManager.TopRight.y - _halfHeight;
         float newY = Mathf.Min(transform.position.y + speed * Time.deltaTime, maxY);
         transform.position = new Vector3(transform.position.x, newY, transform.position.z);

         UpdateTopBottom();
      }

      public void MoveDown()
      {
         UpdateTopBottom();

         float minY = GameManager.BottomLeft.y + _halfHeight;
         float newY = Mathf.Max(transform.position.y - speed * Time.deltaTime, minY);
         transform.position = new Vector3(transform.position.x, newY, transform.position.z);

         UpdateTopBottom();
      }

      public void UpdateTopBottom()
      {
         // Keep bounds correct even if the paddle sprite is scaled.
         _halfHeight = _spriteRenderer.bounds.extents.y;
         top = transform.position.y + _halfHeight;
         bottom = transform.position.y - _halfHeight;
      }
}
