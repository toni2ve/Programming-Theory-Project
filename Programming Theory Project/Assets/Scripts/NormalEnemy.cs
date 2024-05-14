
using Unity.VisualScripting;
using UnityEngine;

public class NormalEnemy : Enemy  // Inheriting from the Enemy class
{
    // Polymorphism -- implementation of abstract method
    protected override void Start()
    {
        this.Health = 60.0f;
        this.Color = Color.blue;
        this.Damage = 2.0f;

        gameObject.GetComponent<MeshRenderer>().material.color = this.Color;
    }
}
