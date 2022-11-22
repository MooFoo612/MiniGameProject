using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform moveSpot;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private Rigidbody2D enemyRB;
    private Vector2 calculatedDirection;
    private Animator enemyAnimator;
    private SpriteRenderer enemySR;
    private float prevX;


    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();
        enemySR = GetComponent<SpriteRenderer>();

        //waitTime = startWaitTime;

        //moveSpot.position = new Vector2(Random.Range(minX,minY), Random.Range(maxX,maxY));
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.fixedDeltaTime);
//
        //prevX = transform.position.x;
//
        //if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f) {
        //    if (waitTime <= 0) {
        //        enemyAnimator.SetBool("isWalking", true);
//
        //        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)); 
        //        
        //        if ((moveSpot.position.x - prevX) > 0) {
        //            enemySR.flipX = false;
        //        } else if ((moveSpot.position.x - prevX) <= 0) {
        //            enemySR.flipX = true;
        //        }
//
        //        waitTime = startWaitTime;
        //    } else {
//
        //        enemyAnimator.SetBool("isWalking", false);
        //        
        //        waitTime -= Time.fixedDeltaTime;
        //    }
        //}
    }
    
    void FixedUpdate() {
        
    }
}

