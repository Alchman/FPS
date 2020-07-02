using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected AudioSource shootAudioSource;
    [SerializeField] protected Transform mainCamera;
    [SerializeField] protected int maxAmmo;
    [SerializeField] protected float fireRate;
    [SerializeField] AudioClip shootSound;

    int ammo;

    private void Start()
    {
        ammo = maxAmmo;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Debug.Log("Weapon update");
        if (Input.GetMouseButtonDown(0))
        {
            if (ammo > 0)
            {
                shootAudioSource.PlayOneShot(shootSound);
                Shoot();
                ammo--;
            }
        }
        InternalUpdate();
    }

    protected abstract void Shoot();

    protected virtual void InternalUpdate()
    {

    }

}
