using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealthController : MonoBehaviour
{
    public int maxHealth;

    public int MaxHealth
    {
        get
        {
            return maxHealth;
        }
    }

    public int currentHealth;

    public int CurrentHealth
    {
        get
        {
            return CurrentHealth;
        }
    }

    public SimpleHealthBar healthBar;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.UpdateBar(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            die();
        }
    }

    private void die()
    {
        Debug.Log("dead");
       // Destroy(gameObject);
    }
}
