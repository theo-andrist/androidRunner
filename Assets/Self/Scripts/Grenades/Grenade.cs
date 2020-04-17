using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float force;

    public float Force
    {
        get
        {
            return force;
        }
    }

    public int damage;

    public int Damage
    {
        get
        {
            return damage;
        }
    }

    public float timer;

    public float Timer
    {
        get
        {
            return timer;
        }
    }

    public GameObject explosionEffect;

    protected void Awake()
    {
        StartCoroutine(makeExplode(timer));
        StartCoroutine(noticePlayer(0.1f));
    }

    protected IEnumerator makeExplode(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        explode();
    }

    protected IEnumerator noticePlayer(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.layer = 9;
    }

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<CharacterHealthController>().takeDamage(damage);
            explode();
        }
    }

    protected void explode()
    {
        Instantiate(explosionEffect, transform.position, Quaternion.Euler(0, 0, 0));
        Destroy(gameObject);
    }
}
