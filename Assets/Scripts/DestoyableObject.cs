using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyableObject : MonoBehaviour
{
    [SerializeField] GameObject destroyedVersion;
    //[SerializeField] int health = 100;

    Health health;

    private void Start()
    {
        health = GetComponent<Health>();

        health.OnDeath += DestroyObject;
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
        Instantiate(destroyedVersion, transform.position, transform.rotation);
    }

    //public void DoDamage(int damage)
    //{
    //    health -= damage;

    //    if (health <= 0)
    //    {
    //        // Destroy(gameObject);
    //        Instantiate(destroyedVersion, transform.position, transform.rotation);
    //    }
    //}
}
