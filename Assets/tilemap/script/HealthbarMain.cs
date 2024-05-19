using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarMain : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    public void SetHealth(int health)
    {
        slider.value = health;
    }
    public void SetMaxhealth(int maxhealth)
    {
        slider.maxValue = maxhealth;
        slider.value = maxhealth;
    } 
    
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
