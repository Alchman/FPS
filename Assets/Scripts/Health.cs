using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public Action OnDeath = delegate {};

    [SerializeField] int health = 100;

    public void DoDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            OnDeath();
        }
    }
}
