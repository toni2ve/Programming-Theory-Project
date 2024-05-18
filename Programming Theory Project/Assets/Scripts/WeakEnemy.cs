
using UnityEngine;

public class WeakEnemy : Enemy  // Inheriting from the Enemy class
{
    // Polymorphism -- implementation of abstract method
    protected override void Start()
    {
        this.MaxHealth = 30.0f;
        this.Color = Color.white;
        this.Damage = 10.0f;
        this.HitRate = 1;
        this.CurrentHealth = this.MaxHealth;
        base.Start();
        // gameObject.GetComponent<MeshRenderer>().material.color = this.Color;
    }
}
