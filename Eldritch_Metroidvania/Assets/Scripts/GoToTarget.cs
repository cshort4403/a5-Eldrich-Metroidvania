using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Detection), typeof(Rigidbody2D))]
public class GoToTarget : MonoBehaviour
{

    public float speed = 400.0f;
    public float MAX_VELOCITY = 20f;

    private Detection detectionComponent;
	private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        detectionComponent = GetComponent<Detection>();
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(detectionComponent.numFoundObjects > 0)
        {
            MoveTo(ChooseTarget());
        }
        
    }

    GameObject ChooseTarget()
    {
        int rnd = UnityEngine.Random.Range(0, detectionComponent.numFoundObjects);

       return detectionComponent.targetGameObjects[rnd];
    }


    void MoveTo(GameObject target)
    {
        float step = speed * Time.deltaTime;

        Vector2 direction = Vector2.ClampMagnitude(target.GetComponent<Rigidbody2D>().position - rb.position, 1);


		if (rb.velocity.magnitude < MAX_VELOCITY)
        {
            rb.AddForce(direction * step);
		}
        else
        {
            rb.velocity = direction * MAX_VELOCITY;
        }

	}

    

}
