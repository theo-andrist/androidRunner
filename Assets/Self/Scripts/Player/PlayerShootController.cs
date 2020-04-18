using Photon.Pun;
using UnityEngine;

public class PlayerShootController : MonoBehaviourPun
{
    [SerializeField] private GameObject grenadePrefab = null;

    [SerializeField] private GameObject spawnpoint = null;

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            TakeInput();
        }
    }

    private void TakeInput()
    {
        if (Input.GetButtonDown("Grenade1"))
        {
            photonView.RPC("Shoot", RpcTarget.All);
        }
    }

    [PunRPC]
    private void Shoot()
    {
        GameObject grenade = Instantiate(grenadePrefab, spawnpoint.transform.position, spawnpoint.transform.localRotation);
        grenade.GetComponent<Rigidbody>().AddForce(spawnpoint.transform.forward * grenade.GetComponent<Grenade>().Force * 100);
    }
}
