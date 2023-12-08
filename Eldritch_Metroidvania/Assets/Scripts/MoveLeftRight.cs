using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_LeftRight : MonoBehaviour
{
    public float moveDistance = 300;
    
    public float moveSpeed = 10;
    public float waitTime = 1;

    private bool doneMoving = false;
    private bool moveLeft = true;

    private float waitDestinationTime = 0;
    private float curDistance = 0;

    private Rigidbody2D rb;

	// Start is called before the first frame update
	void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		rb.freezeRotation = true;
	}

    // Update is called once per frame
    void Update()
    {
        if (curDistance >= moveDistance)
        {
            doneMoving = true;
            curDistance = 0;
        }


        if (!doneMoving && moveLeft)
        {
			rb.velocity = new Vector2(-moveSpeed, 0);
            curDistance += moveSpeed;
        }
        else if(!doneMoving && !moveLeft)
        {
			rb.velocity = new Vector2(moveSpeed, 0);
			curDistance += moveSpeed;
		}
        else if(waitDestinationTime >= waitTime)
        {
			rb.velocity = Vector2.zero;
			waitDestinationTime = 0;
            moveLeft = !moveLeft;
            doneMoving = false;
        }
        else
        {
            rb.velocity = Vector2.zero;
            waitDestinationTime += Time.deltaTime;
        }
		
	}
}
