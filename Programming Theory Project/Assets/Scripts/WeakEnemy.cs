
using UnityEngine;

public class WeakEnemy : Enemy
{
    void Start()
    {
        this.health = 30.0f;
        this.color = Color.white;
        this.damage = 1.0f;

        gameObject.GetComponent<MeshRenderer> ().material.color = this.color;
    }
}
