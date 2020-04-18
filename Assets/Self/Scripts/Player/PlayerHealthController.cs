using Photon.Pun;
using UnityEngine;

public class PlayerHealthController : MonoBehaviourPun
{
    [SerializeField] private int maxHealth = 100;
    
    [SerializeField] private SimpleHealthBar healthBar = null;

    public SimpleHealthBar Healthbar
    {
        set
        {
            healthBar = value;
        }
    }

    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;

        if (photonView.IsMine)
        {
            healthBar.UpdateBar(currentHealth, maxHealth);
        }

        if (currentHealth <= 0)
        {
            die();
        }
        Debug.Log($"{currentHealth + damage} - {damage} = {currentHealth}");
    }

    private void die()
    {
        Debug.Log("dead");
       // Destroy(gameObject);
    }
}
