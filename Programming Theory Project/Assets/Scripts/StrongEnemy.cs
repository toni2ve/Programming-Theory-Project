using UnityEngine;

public class StrongEnemy : Enemy  // Inheriting from the Enemy class
{
    // Polymorphism -- implementation of abstract method
    protected override void Start()
    {
        this.MaxHealth = 100.0f;
        this.Color = Color.red;
        this.Damage = 3.0f;
        this.CurrentHealth = this.MaxHealth;

        gameObject.GetComponent<MeshRenderer>().material.color = this.Color;
    }
}
