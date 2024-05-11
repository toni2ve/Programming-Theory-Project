
using Unity.VisualScripting;
using UnityEngine;

public class NormalEnemy : Enemy
{
    void Start()
    {
        this.health = 2;
        this.color = Color.blue;
        this.damage = 2;

        gameObject.GetComponent<MeshRenderer>().material.color = this.color;
    }
}
