using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float collisionOffset = 0.05f;

    public ContactFilter2D movementFilter;

    Vector2 movementInput;
    Rigidbody2D rb;
    SpriteRenderer sr;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        if(movementInput != Vector2.zero) {
            // Check for collisions
            int count = rb.Cast(
                movementInput,  // x and y values between -1 and 1 that represent the direction from the body to look for collisions
                movementFilter, // Settings that determine where a collision can occur on such as layuers to collide with
                castCollisions, // List of collisions to store the found collisions into after the Cast is finished
                moveSpeed * Time.fixedDeltaTime + collisionOffset); // Amount to cast equal to the movement plus an offset

            if (count == 0) {
                rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
            }
        }
    }


    void OnMove(InputValue movementValue) {
        movementInput = movementValue.Get<Vector2>();
    }
}
