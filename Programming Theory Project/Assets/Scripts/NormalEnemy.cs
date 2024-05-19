
using Unity.VisualScripting;
using UnityEngine;

public class NormalEnemy : Enemy  // Inheriting from the Enemy class
{
    // Polymorphism -- implementation of abstract method
    protected override void Start()
    {
        this.MaxHealth = 60.0f;
        this.Damage = 50.0f;
        this.HitRate = 2;
        this.CurrentHealth = this.MaxHealth;
        this.scorePoint = 30;
        base.Start();
    }
}
