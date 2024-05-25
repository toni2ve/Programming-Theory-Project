using UnityEngine;

public class StrongEnemy : Enemy  // Inheriting from the Enemy class
{
    // implementation of virtual method
    protected override void Start()
    {
        this.MaxHealth = 100.0f;
        this.Damage = 100.0f;
        this.HitRate = 3;
        this.CurrentHealth = this.MaxHealth;
        this.scorePoint = 50;
        base.Start();
    }
}
