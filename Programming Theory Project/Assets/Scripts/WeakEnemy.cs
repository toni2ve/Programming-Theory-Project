
using UnityEngine;

public class WeakEnemy : Enemy
{
    void Start()
    {
        this.health = 1;
        this.color = Color.white;
        this.damage = 1;

        gameObject.GetComponent<MeshRenderer> ().material.color = this.color;
    }
}
