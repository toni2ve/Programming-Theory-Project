
using Unity.VisualScripting;
using UnityEngine;

public class NormalEnemy : Enemy
{
    void Start()
    {
        this.health = 60.0f;
        this.color = Color.blue;
        this.damage = 2.0f;

        gameObject.GetComponent<MeshRenderer>().material.color = this.color;
    }
}
