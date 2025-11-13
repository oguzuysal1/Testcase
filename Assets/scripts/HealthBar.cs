using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider slider;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void updateHealthBar(float currentHealth, float totalHealth)
    {
        slider.value = currentHealth / totalHealth;
    }
}
