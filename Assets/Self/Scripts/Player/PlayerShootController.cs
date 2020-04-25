using Photon.Pun;
using UnityEngine;

public class PlayerShootController : MonoBehaviourPun
{
    [SerializeField] private GameObject grenadePrefab = null;

    [SerializeField] private GameObject spawnpoint = null;

    [SerializeField] private float shootIntervall = 1f;
    private float countdown = 0f;

    private bool shootEnabled = false;

    private void Start()
    {
        countdown = shootIntervall;
    }

    void Update()
    {
        if (countdown >= 0 && !shootEnabled)
        {
            shootIntervall -= Time.deltaTime;
        }
        else
        {
            shootEnabled = true;
            countdown = shootIntervall;
        }

        if (Input.GetButtonDown("Grenade1") && shootEnabled)
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
            shootEnabled = false;
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
