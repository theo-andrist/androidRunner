using Photon.Pun;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab = null;

    [SerializeField] private GameObject playerCamera = null;
    [SerializeField] private Vector3 cameraLocalPositionInPlayer = new Vector3(0, 0.69f, 0.65f);

    [SerializeField] private SimpleHealthBar playerHealthBar = null;

    void Start()
    {
        GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, transform.position, Quaternion.identity);
        SetLayerForObjectAndChildren(player, 10, "CannonG_Barrel02");

        SetCameraSettings(player);

        SetHealthBar(player, playerHealthBar);
    }

    private void SetHealthBar(GameObject player, SimpleHealthBar playerHealthBar)
    {
        player.GetComponent<PlayerHealthController>().Healthbar = playerHealthBar;
    }

    private void SetCameraSettings(GameObject player)
    {
        Transform canon = player.transform.Find("FattyCannonG02/Turret/CannonG_Barrel02");

        playerCamera.transform.SetParent(canon);
        playerCamera.transform.localPosition = cameraLocalPositionInPlayer;

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
