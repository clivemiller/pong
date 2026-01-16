using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
   private Rigidbody2D _rb;
   private Collider2D _collider;

   [SerializeField]
   private Vector2 initialVelocity = new Vector2(2f, 2f);

   private void Awake()
   {
         _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
   }

    void Start()
    {
        Launch();
    }

    private void Launch()
    {
        float x = Mathf.Abs(initialVelocity.x) * (UnityEngine.Random.value < 0.5f ? -1f : 1f);
        float y = Mathf.Abs(initialVelocity.y) * (UnityEngine.Random.value < 0.5f ? -1f : 1f);
        _rb.linearVelocity = new Vector2(x, y);
    }
    
     private float GetExtentY()
    {
            return _collider.bounds.extents.y;
     }

     private float GetExtentX()
     {
            return _collider.bounds.extents.x;
     }

     private void FixedUpdate()
     {
            float extentY = GetExtentY();
            float extentX = GetExtentX();

            float minY = GameManager.BottomLeft.y + extentY;
            float maxY = GameManager.TopRight.y - extentY;

            Vector2 position = _rb.position;

            // Bounce once when passing y bounds.
            if (position.y < minY)
            {
                position.y = minY; // snap so we don't phase
                _rb.position = position;
                // Absolute() to make sure that we go up.
                _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, Mathf.Abs(_rb.linearVelocity.y));
            }
            else if (position.y > maxY)
            {
                position.y = maxY;
                _rb.position = position;
                _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, -Mathf.Abs(_rb.linearVelocity.y));
            }

            float minX = GameManager.BottomLeft.x + extentX;
            float maxX = GameManager.TopRight.x - extentX;

            // Out of bounds horizontally => reset ball.
            if (position.x < minX || position.x > maxX)
            {
                _rb.position = Vector2.zero;
                Launch();
            }
    }
}
