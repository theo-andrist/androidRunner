using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShootController : MonoBehaviour
{
    public GameObject grenadePrefab;

    public GameObject spawnpoint;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Grenade1"))
        {
            shoot();
        }
    }

    private void shoot()
    {
        GameObject grenade = Instantiate(grenadePrefab, spawnpoint.transform.position, spawnpoint.transform.localRotation);
        grenade.GetComponent<Rigidbody>().AddForce(spawnpoint.transform.up * grenade.GetComponent<Grenade>().Force * 100);
    }
}
