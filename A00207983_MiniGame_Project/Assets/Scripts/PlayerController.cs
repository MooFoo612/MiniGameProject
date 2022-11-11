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
    public Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        animator.SetFloat("Speed", 0); 
        animator.SetFloat("Vertical", -1);
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

        if (movementInput != Vector2.zero) {
            animator.SetFloat("Horizontal", movementInput.x);
            animator.SetFloat("Vertical", movementInput.y);
            animator.SetFloat("Speed", 1);
        }
        else {
            animator.SetFloat("Horizontal", movementInput.x);
            animator.SetFloat("Vertical", movementInput.y);
            animator.SetFloat("Speed", 0);            
        }
    }
}
