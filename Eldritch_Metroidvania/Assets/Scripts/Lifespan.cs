using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifespan : MonoBehaviour
{
    
    public float maxLifespan;

    private float aliveTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(aliveTime > maxLifespan)
        {
            Destroy(gameObject);
        }
        else
        {
            aliveTime += Time.deltaTime;
        }
    }
}
