using UnityEngine;

public class StrongEnemy : Enemy
{
    void Start()
    {
        this.health = 3;
        this.color = Color.red;
        this.damage = 3;

        gameObject.GetComponent<MeshRenderer>().material.color = this.color;
    }
}
