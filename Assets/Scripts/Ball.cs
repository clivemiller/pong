using UnityEngine;

public class Ball : MonoBehaviour
{
   //  [SerializeField] private GameManager _gameManager;

   //  void Awake()
   //  {
   //    if (_gameManager == null)
   //    {
   //      _gameManager = FindFirstObjectByType<GameManager>();
   //    }
   //  }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      GetComponent<Rigidbody2D>().linearVelocity = new Vector2(2, 2);

    }

    // Update is called once per frame
    void Update()
    {
      // handle ball hitting top or bottom of screen
      if (GameManager.BottomLeft.y > transform.position.y ||
          GameManager.TopRight.y < transform.position.y)
      {
         GetComponent<Rigidbody2D>().linearVelocity = new Vector2(GetComponent<Rigidbody2D>().linearVelocity.x, -GetComponent<Rigidbody2D>().linearVelocity.y);
      }
    }
}
