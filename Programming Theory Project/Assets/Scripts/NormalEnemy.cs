
using Unity.VisualScripting;
using UnityEngine;

public class NormalEnemy : Enemy  // Inheriting from the Enemy class
{
    // implementation virtual method
    protected override void Start()
    {
        this.MaxHealth = 60.0f;
        this.Damage = 10.0f;
        this.HitRate = 2;
        this.CurrentHealth = this.MaxHealth;
        this.scorePoint = 30;
        base.Start();
    }
}
