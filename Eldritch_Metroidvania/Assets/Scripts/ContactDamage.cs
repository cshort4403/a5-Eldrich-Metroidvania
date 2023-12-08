using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamage : MonoBehaviour
{
    public FloatVariable playerHealth;
    public float damage;
    public float damageRate = 10f;


    private float timeSinceLastDamage = 0;

    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastDamage += Time.deltaTime;
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (timeSinceLastDamage > damageRate)
        {
            if (collision != null)
            {
                if (collision.gameObject.CompareTag("Player"))
                {
                    playerHealth.value -= damage;
                    timeSinceLastDamage = 0;
                }
            }
        }
	}
}
