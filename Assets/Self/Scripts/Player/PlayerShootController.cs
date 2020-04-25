using Photon.Pun;
using UnityEngine;

public class PlayerShootController : MonoBehaviourPun
{
    [SerializeField] private GameObject grenadePrefab = null;

    [SerializeField] private GameObject spawnpoint = null;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Grenade1"))
        {
            if (TestController.IsTesting)
            {
                Shoot();
            }
            else
            {
                if (photonView.IsMine)
                {
                    photonView.RPC("ShootRPC", RpcTarget.All);
                }
            }
        }
    }
    private void Shoot()
    {
        
        GameObject grenade = Instantiate(grenadePrefab, spawnpoint.transform.position, spawnpoint.transform.localRotation);
        Grenade grenadeScript = grenade.GetComponent<Grenade>();
        grenadeScript.Thrower = gameObject;
        grenade.GetComponent<Rigidbody>().AddForce(spawnpoint.transform.forward * grenadeScript.Force * 100);
    }
    [PunRPC]
    private void ShootRPC()
    {
        GameObject grenade = Instantiate(grenadePrefab, spawnpoint.transform.position, spawnpoint.transform.localRotation);
        Grenade grenadeScript = grenade.GetComponent<Grenade>();
        grenadeScript.Thrower = gameObject;
        grenade.GetComponent<Rigidbody>().AddForce(spawnpoint.transform.forward * grenadeScript.Force * 100);
    }
}
