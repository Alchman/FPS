using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] int damage = 200;
    [SerializeField] float explosionRadius = 5f;
    [SerializeField] float explosionForce = 10f;
    [SerializeField] float yForce = 5f;
    [SerializeField] LayerMask explosionLayerMask;

    public void DoDamage(int damage)
    {
        health -= damage;
        
        if (health <= 0)
        {
            Explode();
        }
    }

    private void Explode()
    {
        //TODO play sound
        //TODO play explosion effect

        Destroy(gameObject);

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, explosionLayerMask);
        foreach(Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, yForce);
            }

            DestoyableObject destroyable = collider.GetComponent<DestoyableObject>();
            if (destroyable != null)
            {
                destroyable.DoDamage(damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
