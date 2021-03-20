using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
  Rigidbody2D rb;
  SpriteRenderer sprite;

  float horizontal;
  float vertical;
  float moveLimiter = 0.7f;

  public float runSpeed = 20.0f;


  Vector3 previousPosition;

  [Header("Infos")]
  [ReadOnly] [SerializeField] float distance = 0;

  [ShowNonSerializedField] public static bool CanMove = true;

  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    sprite = GetComponent<SpriteRenderer>();

    previousPosition = transform.position;

  }

  void Update()
  {

    if (CanMove)
    {
      horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
      vertical = Input.GetAxisRaw("Vertical"); // -1 is down


      if (horizontal != 0) sprite.flipX = horizontal < 0 ? true : false;
    }

    distance += Vector3.Distance(previousPosition, transform.position);
  }

  void FixedUpdate()
  {
    if (horizontal != 0 && vertical != 0) // Check for diagonal movement
    {
      // limit movement speed diagonally, so you move at 70% speed
      horizontal *= moveLimiter;
      vertical *= moveLimiter;
    }

    rb.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);



  }


  public void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("Interactable") == false) return;
    Interactable interactable = collision.GetComponent<Interactable>();
    if (interactable == null) return;

    interactable.WaitForInteract();
  }


  private void OnTriggerExit2D(Collider2D collision)
  {
    if (collision.CompareTag("Interactable") == false) return;
    Interactable interactable = collision.GetComponent<Interactable>();
    if (interactable == null) return;

    interactable.EndInteract();
  }


  private void LateUpdate()
  {
    previousPosition = transform.position;
  }
}
