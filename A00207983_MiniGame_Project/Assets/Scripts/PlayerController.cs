using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    Vector2 movementInput;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {/*
        if(movementInput != Vector2.zero) {
            // Check for collisions
            int count = rb.Cast(
                direction,  // x and y values between -1 and 1 that represent the direction from the body to look for collisions
                movementFilter, // Settings that determine where a collision can occur on such as layuers to collide with
                castCollisions, // List of collisions to store the found collisions into after the Cast is finished
                moveSpeed * Time.fixedDeltaTime + collisionOffset); // Amount to cast equal to the movement plus an offset
        }*/
    }


    void OnMove(InputValue movementValue) {
       // movementInput = movementValue.Get<Vector2>();
    }
}
