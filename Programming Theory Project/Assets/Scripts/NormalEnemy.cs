
using Unity.VisualScripting;
using UnityEngine;

public class NormalEnemy : Enemy  // Inheriting from the Enemy class
{
    // Polymorphism -- implementation of abstract method
    protected override void Start()
    {
        this.MaxHealth = 60.0f;
        this.Color = Color.blue;
        this.Damage = 50.0f;
        this.HitRate = 2;
        this.CurrentHealth = this.MaxHealth;
        base.Start();
        // gameObject.GetComponent<MeshRenderer>().material.color = this.Color;
    }
}
