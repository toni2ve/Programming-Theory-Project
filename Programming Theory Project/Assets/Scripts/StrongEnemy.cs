using UnityEngine;

public class StrongEnemy : Enemy
{
    void Start()
    {
        this.health = 100.0f;
        this.color = Color.red;
        this.damage = 3.0f;

        gameObject.GetComponent<MeshRenderer>().material.color = this.color;
    }
}
