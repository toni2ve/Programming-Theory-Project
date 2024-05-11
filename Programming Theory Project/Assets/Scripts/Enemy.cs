using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float health { get; set; }
    public Color color { get; set; }
    public float damage { get; set; }

    void Start()
    {
        this.health = 0.0f;
        this.color = Color.black;
        this.damage = 0.0f;

        gameObject.GetComponent<MeshRenderer>().material.color = this.color;
    }

    void Update()
    {
        FollowPlayer();
    }

    public void TakeDamage(float damageAmount)
    {
        Debug.Log("health" +health+ "damage taken : "+ damageAmount);
        health -= damageAmount;
        Debug.Log("new health" +health);
        
        if( health <= 0f){
            Die();
        }
    }

    void Die(){
        Destroy(gameObject);
    }

    protected void FollowPlayer()
    {
        NavMeshAgent enemy = gameObject.GetComponent<NavMeshAgent>();
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            enemy.SetDestination(player.transform.position);
        }
    }


}
