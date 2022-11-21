using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float collisionOffset = 0.05f;
    public static int health = 15;
    public static int maxHealth = 20;

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
        animator.SetFloat("Horizontal", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        // Attempting greasySweet movement:

        // Check for movement input
        if(movementInput != Vector2.zero) {
            bool moveSuccess = TryMove(movementInput);

            // If not successful
            if (!moveSuccess) {
                // Check against X axis
                moveSuccess = TryMove(new Vector2(movementInput.x, 0));

                //If still not successful
                if (!moveSuccess) {
                    // Check along the Y axis
                    moveSuccess = TryMove(new Vector2(0, movementInput.y));
                }
            }
        }
    }

    private bool TryMove(Vector2 direction) {
        // Check for collisions
        int checkCollision = rb.Cast(
            // X and Y values <->(-1,1) representing the direction from the body to look for collisions
            direction,
            // Settings that determine where a collision can occur on such as layuers to collide with  
            movementFilter,
            // List of collisions to store the found collisions into after the Cast is finished 
            castCollisions,
            // Amount to cast equal to the movement plus an offset
            moveSpeed * Time.fixedDeltaTime + collisionOffset); 

        if (checkCollision == 0) {
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
            return true;        
        } else {
            return false;
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

    void OnFire() {
        movementInput = Vector2.zero;
        
        animator.SetTrigger("Attack");
    }
}
