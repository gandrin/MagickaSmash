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
  public int playerId = 1;
  public LayerMask groundLayers;

  void Start()
  {
    // 5 - Get the component and store the reference
    rigidbodyComponent = GetComponent<Rigidbody2D>();
    colliderComponent = GetComponent<BoxCollider2D>();
  }
  void Update()
  {
    if (playerId == 1) {
      if(Input.GetKey(KeyCode.Z))
          this.Jump();
      if(Input.GetKey(KeyCode.D))
          this.MoveRight();
      if(Input.GetKey (KeyCode.Q))
          this.MoveLeft();
    } else if (playerId == 2) {
      if(Input.GetKey(KeyCode.LeftArrow))
          this.MoveLeft();
      if(Input.GetKey(KeyCode.RightArrow))
          this.MoveRight();
      if(Input.GetKey (KeyCode.UpArrow))
          this.Jump();
    }

    // 5 - Shooting
    bool shoot = Input.GetButtonDown("Fire1");
    shoot |= Input.GetButtonDown("Fire2");
    // Careful: For Mac users, ctrl + arrow is a bad idea

    if (shoot)
    {
      WeaponScript weapon = GetComponent<WeaponScript>();
      if (weapon != null)
      {
        // false because the player is not an enemy
        weapon.Attack(false);
      }
    }    
  }

  void Jump()
  {
    rigidbodyComponent.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
  }

  void MoveLeft()
  {
    rigidbodyComponent.velocity = new Vector2(
      -speed.x, 0
    );
  }

  void MoveRight()
  {
    rigidbodyComponent.velocity = new Vector2(
      speed.x, 0
    );
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

