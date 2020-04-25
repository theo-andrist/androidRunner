using System.Collections;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] protected float force = 11;

    public float Force
    {
        get
        {
            return force;
        }
    }

    [SerializeField] protected int damage = 20;

    public int Damage
    {
        get
        {
            return damage;
        }
    }

    [SerializeField] protected float timer = 3.5f;

    public float Timer
    {
        get
        {
            return timer;
        }
    }

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
            collision.gameObject.GetComponent<PlayerHealthController>().takeDamage(damage);
            explode();
        }
    }

    protected void explode()
    {
        Instantiate(explosionEffect, transform.position, Quaternion.Euler(0, 0, 0));
        Destroy(gameObject);
    }
}
