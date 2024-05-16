
using UnityEngine;

public class WeakEnemy : Enemy  // Inheriting from the Enemy class
{
    // Polymorphism -- implementation of abstract method
    protected override void Start()
    {
        this.MaxHealth = 30.0f;
        this.Color = Color.white;
        this.Damage = 1.0f;
        this.CurrentHealth = this.MaxHealth;

        gameObject.GetComponent<MeshRenderer>().material.color = this.Color;
    }
}
