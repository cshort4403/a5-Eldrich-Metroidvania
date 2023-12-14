using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ContactDamage : MonoBehaviour
{
    public FloatVariable playerHealth;
    public FloatVariable enemyHealth;
    public float damage;
    public float damageRate = 1f;
    

    private float timeSinceLastDamage = 100;
    
    
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
				if (collision.gameObject.CompareTag("Enemy"))
				{
                    float enemyHealth = (float)Variables.Object(collision.gameObject).Get("enemyHealth");
                    enemyHealth -= damage;
					Variables.Object(collision.gameObject).Set("enemyHealth", enemyHealth);

                    if(enemyHealth <= 0) 
                    {
                        Destroy(collision.gameObject);
					}


					timeSinceLastDamage = 0;
				}

			}
        }
	}
}
