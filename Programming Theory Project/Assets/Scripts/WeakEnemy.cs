
using UnityEngine;

public class WeakEnemy : Enemy  // Inheriting from the Enemy class
{
    // Polymorphism -- implementation of abstract method
    protected override void Start()
    {
        this.Health = 30.0f;
        this.Color = Color.white;
        this.Damage = 1.0f;

        gameObject.GetComponent<MeshRenderer>().material.color = this.Color;
    }
}
