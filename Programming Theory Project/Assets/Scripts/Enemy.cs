using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int health { get; protected set; }
    public Color color { get; protected set; }
    public int damage { get; protected set; }

    void Start()
    {
        this.health = 0;
        this.color = Color.black;
        this.damage = 0;

        gameObject.GetComponent<MeshRenderer>().material.color = this.color;
    }

    void Update()
    {
        FollowPlayer();
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
