using Photon.Pun;
using UnityEngine;

public class PlayerHealthController : MonoBehaviourPun
{

    [SerializeField] private GameObject deadPlayerPrefab = null;

    [SerializeField] private int maxHealth = 100;

    private PlayerSpawner playerSpawner = null;
    public PlayerSpawner PlayerSpawner
    {
        set
        {
            playerSpawner = value;
        }
    }

    private GameObject playerAliveUI;
    public GameObject PlayerAliveUI
    {
        set
        {
            playerAliveUI = value;
        }
    }

    private GameObject playerDeadUI;
    public GameObject PlayerDeadUI
    {
        set
        {
            playerDeadUI = value;
        }
    }

    private int currentHealth = 0;
    private SimpleHealthBar healthBar = null;

    private void Start()
    {
        currentHealth = maxHealth;

        if (photonView.IsMine)
        {
            healthBar = playerAliveUI.transform.Find("FancyBar/Healthbar").GetComponent<SimpleHealthBar>();
            healthBar.UpdateBar(currentHealth, maxHealth);
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (photonView.IsMine || TestController.IsTesting)
        {
            healthBar.UpdateBar(currentHealth, maxHealth);

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        GameObject deadPlayer = PhotonNetwork.Instantiate(deadPlayerPrefab.name, transform.position, Quaternion.identity);

        DeadPlayerRespawnManager deadPlayerManager = deadPlayer.GetComponent<DeadPlayerRespawnManager>();

        deadPlayerManager.PlayerAliveUI = playerAliveUI;
        deadPlayerManager.PlayerDeadUI = playerDeadUI;
        deadPlayerManager.PlayerSpawner = playerSpawner;
        deadPlayerManager.InitializeText();

        playerAliveUI.SetActive(false);
        playerDeadUI.SetActive(true);

        Camera.main.gameObject.transform.SetParent(deadPlayer.transform.Find("FattyCannonG02/Turret/CannonG_Barrel02"));

        PhotonNetwork.Destroy(gameObject);
    }
}
