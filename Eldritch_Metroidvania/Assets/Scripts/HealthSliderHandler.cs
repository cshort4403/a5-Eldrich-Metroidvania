using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthSliderHandler : MonoBehaviour
{
    public FloatVariable curHealth;
    public FloatVariable maxHealth;

    public Slider healthSlider;

    // Start is called before the first frame update
    void Start()
    {
        //healthSlider = GetComponent<Slider>();
        healthSlider.maxValue = maxHealth.value;
        curHealth.value = maxHealth.value;


    }

    // Update is called once per frame
    void Update()
    {
		if (gameObject.tag == "Enemy")
		{
			healthSlider.value = (float)Variables.Object(gameObject).Get("enemyHealth");
		}
        else
        {
			healthSlider.value = curHealth.value;
		}
	}
}
