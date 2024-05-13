using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    string healthStr;
    private int maxHealth = 100;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthStr = currentHealth.ToString();
        healthText.text = "Health = " + healthStr;

        if(currentHealth <= 0)
        {
            currentHealth = 0;
        }
    }
}
