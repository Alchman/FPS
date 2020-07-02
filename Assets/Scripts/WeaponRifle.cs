using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRifle : Weapon
{
    [SerializeField] float range = 100f;
    [SerializeField] int damage = 30;
    [SerializeField] LayerMask damageLayerMask;
    [SerializeField] ParticleSystem flashEffect;

    [Header("Impact")]
    [SerializeField] float impactForce = 10f;
    [SerializeField] GameObject impactEffect;


    protected override void Update()
    {
        base.Update();

    }

    protected override void InternalUpdate()
    {
        //Debug.Log("Internal update");
    }


    protected override void Shoot()
    {
        flashEffect.Play();

        //Debug.DrawRay(mainCamera.position, mainCamera.forward * range, Color.red, 10f);

        RaycastHit hit;
        if (Physics.Raycast(mainCamera.position, mainCamera.forward, out hit, range, damageLayerMask))
        {
            //TODO use Pool
            Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

            Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce((hit.point - mainCamera.position).normalized * impactForce);
            }

            Health health = hit.collider.GetComponent<Health>();
            if (health != null)
            {
                health.DoDamage(damage);
            }



            //ITarget target = hit.collider.GetComponent<ITarget>();
            //if (target != null)
            //{
            //    target.DoDamage(damage);
            //}

            //DestoyableObject destroyable = hit.collider.GetComponent<DestoyableObject>();
            //if (destroyable != null)
            //{
            //    destroyable.DoDamage(damage);
            //}

            //Bomb bomb = hit.collider.GetComponent<Bomb>();
            //if (bomb != null)
            //{
            //    bomb.DoDamage(damage);
            //}

        }
    }
}
