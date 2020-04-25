using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class DeadPlayerRespawnManager : MonoBehaviour
{
    [SerializeField] private float countdown = 3.0f;
    private Text countdownText = null;

    private PlayerSpawner playerSpawner = null;
    public PlayerSpawner PlayerSpawner
    {
        set
        {
            playerSpawner = value;
        }
    }

    private GameObject playerAliveUI = null;
    public GameObject PlayerAliveUI
    {
        set
        {
            playerAliveUI = value;
        }
    }
    private GameObject playerDeadUI = null;
    public GameObject PlayerDeadUI
    {
        set
        {
            playerDeadUI = value;
        }
    }

    public void InitializeText()
    {
        countdownText = playerDeadUI.transform.Find("RedPanel/CountdownText").GetComponent<Text>();
    }

    void Update()
    {
        if (GetComponent<PhotonView>().IsMine)
        {
            countdown -= Time.deltaTime;

            countdownText.text = (countdown).ToString("0");

            if (countdown < 0)
            {
                playerDeadUI.SetActive(false);
                playerAliveUI.SetActive(true);
                playerSpawner.SpawnPlayer();
                PhotonNetwork.Destroy(gameObject);
            }
        }
    }
}
