using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRifle : MonoBehaviour
{
    [SerializeField] Transform mainCamera;
    [SerializeField] float range = 100f;
    [SerializeField] LayerMask damageLayerMask;
    [SerializeField] ParticleSystem flashEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            flashEffect.Play();
            //TODO play sound


            //Debug.DrawRay(mainCamera.position, mainCamera.forward * range, Color.red, 10f);

            RaycastHit hit;
            if (Physics.Raycast(mainCamera.position, mainCamera.forward, out hit, range, damageLayerMask))
            {
                //TODO spawn impact effect

                Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddForce(mainCamera.forward - mainCamera.position);
                }

            }
        }
    }
}
