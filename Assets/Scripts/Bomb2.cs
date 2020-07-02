using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb2 : Bomb
{
    [SerializeField] int number;

    public override void Explode()
    {
        base.Explode();

        GetExplosionRadius();

        Debug.Log("Explode Bomb 2");
    }

    public void NewMethod()
    {
        Debug.Log("I am bomb 2");
    }
}
