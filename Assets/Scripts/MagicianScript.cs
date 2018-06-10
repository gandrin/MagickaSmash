using UnityEngine;

/// <summary>
/// Player controller and behavior
/// </summary>
public class MagicianScript : MonoBehaviour
{
  /// <summary>
  /// 1 - The speed of the ship
  /// </summary>
  public Vector2 speed = new Vector2(50, 50);
  // 2 - Store the movement and the component
  private Vector2 movement;
  private Rigidbody2D rigidbodyComponent;
  private BoxCollider2D colliderComponent;
  public int jumpForce = 7;
  public LayerMask groundLayers;

  void Start()
  {
    // 5 - Get the component and store the reference
    rigidbodyComponent = GetComponent<Rigidbody2D>();
    colliderComponent = GetComponent<BoxCollider2D>();
  }
  void Update()
  {
    // 3 - Retrieve axis information
    float inputX = Input.GetAxis("Horizontal");
    float inputY = Input.GetAxis("Vertical");

    // 4 - Movement per direction
    movement = new Vector2(
      speed.x * inputX,
      speed.y * inputY
    );

    rigidbodyComponent.velocity = movement;

    if (Input.GetKeyDown(KeyCode.Space) /*&& IsGrounded()*/)
    {
      rigidbodyComponent.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
  }

  void FixedUpdate()
  {
    // 6 - Move the game object
  }
  // bool IsGrounded()
  // {
  //   return Physics.CheckBox(
  //     colliderComponent.bounds.center,
  //     new Vector2(colliderComponent.bounds.center.x, colliderComponent.bounds.min.y),
  //     colliderComponent.size.y * 9f,
  //     groundLayers
  //   );
  // }
}

