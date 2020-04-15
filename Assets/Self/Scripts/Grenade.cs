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

    public float damage;

    public float Damage
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
}
