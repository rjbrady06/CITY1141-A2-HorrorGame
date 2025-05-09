using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    Image mainHealthBar, followHealthBar;

    [SerializeField]
    Color decreaseColour, increaseColour;

    [SerializeField]
    float maxHealth, currentHealth, followHealth, followSpeed = 2f;

    [SerializeField]
    float damage = 10;

    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;
        followHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        mainHealthBar.fillAmount = currentHealth / maxHealth;
        followHealth = Mathf.Lerp(followHealth, currentHealth, Time.deltaTime * followSpeed);
        followHealthBar.color = currentHealth > followHealth ? increaseColour : decreaseColour;
        followHealthBar.transform.SetSiblingIndex(0);
        followHealthBar.fillAmount = followHealth / maxHealth;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReduceHealth();
        } 
        if (Input.GetKeyDown(KeyCode.Return))
        {
            IncreaseHealth();
        }

    }

    void ReduceHealth()
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);   
    }
    void IncreaseHealth()
    {
        currentHealth = Mathf.Clamp(currentHealth + damage, 0, maxHealth);   
    }
    
    
}
