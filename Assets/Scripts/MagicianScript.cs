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
  private WeaponScript weaponComponent;
  public int jumpForce = 7;
  public int playerId = 1;
  bool isJumping = false;
  public LayerMask groundLayers;

  void Start()
  {
    // 5 - Get the component and store the reference
    rigidbodyComponent = GetComponent<Rigidbody2D>();
    colliderComponent = GetComponent<BoxCollider2D>();
    weaponComponent = GetComponent<WeaponScript>();
  }
  void Update()
  {
    if (playerId == 1)
    {
      if (Input.GetKey(KeyCode.Z))
        this.Jump();
      if (Input.GetKey(KeyCode.D))
        this.MoveRight();
      if (Input.GetKey(KeyCode.Q))
        this.MoveLeft();
      if (Input.GetButtonDown("Fire1"))
        this.Shoot();
    }
    else if (playerId == 2)
    {
      if (Input.GetKey(KeyCode.LeftArrow))
        this.MoveLeft();
      if (Input.GetKey(KeyCode.RightArrow))
        this.MoveRight();
      if (Input.GetKey(KeyCode.UpArrow))
        this.Jump();
      if (Input.GetButtonDown("Fire2"))
        this.Shoot();
    }

    // Jumping
    if(rigidbodyComponent.velocity.y == 0)
      this.isJumping = false;

    var dist = (transform.position - Camera.main.transform.position).z;

    var leftBorder = Camera.main.ViewportToWorldPoint(
      new Vector3(0, 0, dist)
    ).x;

    var rightBorder = Camera.main.ViewportToWorldPoint(
      new Vector3(1, 0, dist)
    ).x;

    var topBorder = Camera.main.ViewportToWorldPoint(
      new Vector3(0, 0, dist)
    ).y;

    var bottomBorder = Camera.main.ViewportToWorldPoint(
      new Vector3(0, 1, dist)
    ).y;

    transform.position = new Vector3(
      Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
      Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
      transform.position.z
    );
  }

  void Shoot()
  {
    weaponComponent.Attack(false);
  }

  void Jump()
  {
    if(IsGrounded() && !this.isJumping){
      rigidbodyComponent.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
      this.isJumping = true;
    }
  }

  bool IsGrounded(){
    return rigidbodyComponent.IsTouchingLayers(groundLayers);
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
}

