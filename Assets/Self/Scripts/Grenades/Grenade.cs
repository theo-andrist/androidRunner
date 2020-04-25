using System.Collections;
using UnityEngine;
using Photon.Pun;

public class Grenade : MonoBehaviour
{
    protected GameObject thrower = null;
    public GameObject Thrower
    {
        set
        {
            thrower = value;
        }
    }

    [SerializeField] protected float force = 9;
    public float Force
    {
        get
        {
            return force;
        }
    }

    [SerializeField] protected int damage = 20;
    [SerializeField] protected float timer = 3.5f;
    [SerializeField] protected float radius = 0.5f;

    [SerializeField] protected GameObject explosionEffect = null;

    private int grenadeExplodeLayerId = 9;

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
        gameObject.layer = grenadeExplodeLayerId;
    }

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            explode();
            collision.gameObject.GetComponent<PlayerHealthController>().TakeDamage(damage);
        }
    }

    protected void explode()
    {
        Instantiate(explosionEffect, transform.position, Quaternion.Euler(0, 0, 0));
        Destroy(gameObject);
    }
}
