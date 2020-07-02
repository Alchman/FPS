using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
  //  [SerializeField] int health = 100;
    [SerializeField] protected int damage = 200;
    [SerializeField] protected float explosionRadius = 5f;
    [SerializeField] protected float explosionForce = 10f;
    [SerializeField] protected float yForce = 5f;
    [SerializeField] protected LayerMask explosionLayerMask;

    //public void DoDamage(int damage)
    //{
    //    health -= damage;

    //    if (health <= 0)
    //    {
    //        Explode();
    //    }
    //}

    Health health;

    private void Start()
    {
        health = GetComponent<Health>();

        health.OnDeath += Explode;
    }


    public virtual void Explode()
    {
        Debug.Log("Explode Bomb original");
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

            //DestoyableObject destroyable = collider.GetComponent<DestoyableObject>();
            //if (destroyable != null)
            //{
            //    destroyable.DoDamage(damage);
            //}
        }
    }

    protected float GetExplosionRadius()
    {
        return explosionRadius;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
