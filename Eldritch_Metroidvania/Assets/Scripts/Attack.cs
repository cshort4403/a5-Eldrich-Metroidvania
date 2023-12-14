using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Attack : MonoBehaviour
{

    public float damage;
    public float coolDown; //The time between attacks. Lower values are faster.
    public float attackDuration;
    public GameObject attackObject;

    public bool shouldAttack = false;

    //Animation component

    private float attackTime = 0;


    // Start is called before the first frame update
    void Start()
    {
		attackObject.GetComponent<Lifespan>().maxLifespan = attackDuration;
		attackObject.GetComponent<ContactDamage>().damage = damage;
		attackObject.transform.position = new Vector3(gameObject.GetComponent<CapsuleCollider2D>().size.x, 0);
	}

    // Update is called once per frame
    void Update()
    {
        if (attackTime >= attackDuration + coolDown)
        {
            if (Input.GetMouseButtonDown(0))
            {
                CreateWeaponObject();
                attackTime = 0;
            }

        }
        else
        {
            attackTime += Time.deltaTime;
        }
        
	}

    void CreateWeaponObject()
    {
		Instantiate(attackObject, gameObject.GetComponent<Rigidbody2D>().transform, false);
	}



}
