
using UnityEngine;

public class WeakEnemy : Enemy  // Inheriting from the Enemy class
{
    // Polymorphism -- implementation of abstract method
    protected override void Start()
    {
        this.MaxHealth = 30.0f;
        this.Damage = 3.0f;
        this.HitRate = 1;
        this.CurrentHealth = this.MaxHealth;
        this.ScorePoint = 10;
        base.Start();
    }
}
