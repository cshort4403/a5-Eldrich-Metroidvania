using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSliderHandler : MonoBehaviour
{
    public FloatVariable playerHealth;
    public FloatVariable maxPlayerHealth;

    Slider healthSlider;

    // Start is called before the first frame update
    void Start()
    {
        healthSlider = GetComponent<Slider>();
        healthSlider.maxValue = maxPlayerHealth.value;
        playerHealth.value = maxPlayerHealth.value;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = playerHealth.value;
    }
}
