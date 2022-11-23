using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAggro : MonoBehaviour
{
    public GameObject target;
    public GameObject enemy;
    public float mvmtSpd;

    private Rigidbody2D enemyRB;
    private Animator enemyAnimator;
    private SpriteRenderer enemySR;
    private Vector2 calculatedDirection;
    private bool targetSpotted = false;

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = enemy.GetComponent<Rigidbody2D>();

        enemyAnimator.SetFloat("Speed", 0); 
        enemyAnimator.SetFloat("Vertical", -1);
        enemyAnimator.SetFloat("Horizontal", 0);
        enemyAnimator.SetBool("isWalking", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        if (targetSpotted) {
            calculatedDirection = (target.transform.position - enemy.transform.position).normalized;
            enemyRB.velocity = calculatedDirection * mvmtSpd;
        } else {
            enemyRB.velocity = new Vector2(0,0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name.Equals(target.name)) {
            enemyAnimator.SetFloat("Speed", 1);
            Debug.Log("Entered Aggro Zone: " + enemy.name);
            targetSpotted = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.name.Equals(target.name)) {
            enemyAnimator.SetBool("Speed", false);
            Debug.Log("Exit: " + enemy.name);
            targetSpotted = false;
        }
    }
}
