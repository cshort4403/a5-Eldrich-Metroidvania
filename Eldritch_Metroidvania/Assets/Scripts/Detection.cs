using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(Rigidbody2D))]
public class Detection : MonoBehaviour
{
	public GameObject[] targetGameObjects;

	public string targetTag;
	public float range = 100;
	public int numFoundObjects = 0;
	private Rigidbody2D rb;
	
	private GameObject[] detectableGameObjects;
	

	// Start is called before the first frame update
	void Start()
    {
        rb = GetComponent<Rigidbody2D>();

		detectableGameObjects = GameObject.FindGameObjectsWithTag(targetTag);
		targetGameObjects = new GameObject[detectableGameObjects.Length];

    }

    // Update is called once per frame
    void FixedUpdate()
    {
		numFoundObjects = 0;
		targetGameObjects = new GameObject[detectableGameObjects.Length];
		if (detectableGameObjects.Length > 0)
		{
			foreach (GameObject targetObj in detectableGameObjects)
			{
				if (IsInRange(targetObj))
				{
					targetGameObjects[numFoundObjects] = targetObj;
					numFoundObjects++;
				}
			}
		}
		
	}

	bool IsInRange(GameObject target)
	{
		if (target == null)
		{
			return false;
		}

		float deltaX = target.GetComponent<Rigidbody2D>().position.x - rb.position.x;
		float deltaY = target.GetComponent<Rigidbody2D>().position.y - rb.position.y;

		float distance = Mathf.Sqrt(deltaX * deltaX + deltaY * deltaY);

		return distance <= range;
		

	}
}
