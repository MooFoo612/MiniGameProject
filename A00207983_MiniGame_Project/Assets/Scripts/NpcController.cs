using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform moveSpot;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private Rigidbody2D npcRB;
    private Vector2 calculatedDirection;
    private Animator npcAnimator;
    private SpriteRenderer npcSR;
    private float prevX;


    // Start is called before the first frame update
    void Start()
    {
        npcRB = GetComponent<Rigidbody2D>();
        npcAnimator = GetComponent<Animator>();
        npcSR = GetComponent<SpriteRenderer>();

        waitTime = startWaitTime;

        //moveSpot.position = new Vector2(Random.Range(minX,minY), Random.Range(maxX,maxY));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.fixedDeltaTime);

        prevX = transform.position.x;

        if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f) {
            if (waitTime <= 0) {
                npcAnimator.SetBool("isWalking", true);

                moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)); 
                
                if ((moveSpot.position.x - prevX) > 0) {
                    npcSR.flipX = false;
                } else if ((moveSpot.position.x - prevX) <= 0) {
                    npcSR.flipX = true;
                }

                waitTime = startWaitTime;
            } else {

                npcAnimator.SetBool("isWalking", false);
                
                waitTime -= Time.fixedDeltaTime;
            }
        }
    }
    
    void FixedUpdate() {
        
    }
}
