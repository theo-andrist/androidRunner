using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGrenade : Grenade
{
    public GameObject explosionEffect;

    public Rigidbody myRigidbody;

    private bool outOfPlayer;

    private void Awake()
    {
        StartCoroutine(makeExplode(timer));
        StartCoroutine(noticePlayer(0.1f));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            explode();
        }
    }

    private void explode()
    {
        Instantiate(explosionEffect, transform.position, Quaternion.Euler(0,0,0));
        Destroy(gameObject);
    }

    private IEnumerator makeExplode(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        explode();
    }
    private IEnumerator noticePlayer(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.layer = 9;
    }
}
