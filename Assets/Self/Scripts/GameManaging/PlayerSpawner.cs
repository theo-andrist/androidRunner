using System;
using Photon.Pun;
using UnityEngine;


public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab = null;

    [SerializeField] private Transform[] spawnPoint = null;

    [SerializeField] private GameObject playerCamera = null;
    [SerializeField] private Vector3 cameraLocalPositionInPlayer = new Vector3(0, 0.69f, 0.65f);

    [SerializeField] private GameObject playerAliveUI = null;
    [SerializeField] private GameObject playerDeadUI = null;

    private GameObject player;

    void Start()
    {
        SpawnPlayer();
    }
    public void SpawnPlayer()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            player = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint[0].position, Quaternion.identity);
        }
        else
        {
            player = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint[1].position, Quaternion.identity);
        }

        SetLayerForObjectAndChildren(player, 10, "CannonG_Barrel02");

        SetCameraInPlayer();

        SetPlayerProperties();
    }
    private void SetCameraInPlayer()
    {
        Transform canon = player.transform.Find("FattyCannonG02/Turret/CannonG_Barrel02");

        playerCamera.transform.SetParent(canon);
        playerCamera.transform.localPosition = cameraLocalPositionInPlayer;
    }

    private void SetPlayerProperties()
    {
        PlayerHealthController playerHealthController = player.GetComponent<PlayerHealthController>();

        playerHealthController.PlayerSpawner = this;
        playerHealthController.PlayerAliveUI = playerAliveUI;
        playerHealthController.PlayerDeadUI = playerDeadUI;        
    }

    private void SetLayerForObjectAndChildren(GameObject _object, int layerId, string ignoreChildName)
    {
        if (_object.name != ignoreChildName)
        {
            _object.layer = layerId;
        }

        foreach (Transform child in _object.transform)
        {
            SetLayerForObjectAndChildren(child.gameObject, layerId, ignoreChildName);
        }
    }
}
