using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private float maxHealth;
    private float currenthHealth;
    private float hitRate;
    public HealthBar healthBar;
    private Color color;
    private float damage;
    protected float nextTimeToHit = 0f;

    NavMeshAgent enemyMeshAgent = null;
    Animator animator = null;
    GameObject player = null;
    public float MaxHealth
    {
        get { return maxHealth; }
        protected set   // Encapsulation -- Only Inherited classes can set the value
        {
            if (value < 0)
                maxHealth = 30.0f;

            maxHealth = value;
        }
    }
    public float CurrentHealth
    {
        get { return currenthHealth; }
        protected set   // Encapsulation -- Only Inherited classes can set the value
        {
            currenthHealth = value;
        }
    }
    public Color Color
    {
        get { return color; }
        protected set   // Encapsulation -- Only Inherited classes can set the value
        {
            color = value;
        }
    }
    public float Damage
    {
        get { return damage; }
        protected set   // Encapsulation -- Only Inherited classes can set the value
        {
            if (value < 0)
                damage = 1.0f;

            damage = value;
        }
    }

    public float HitRate { get => hitRate; protected set => hitRate = value; }

    // Abstract method
    protected virtual void Start()
    {
        enemyMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        animator = gameObject.GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        animator.SetBool("isIdle", true);
        animator.SetBool("isFollowingPlayer", false);
    }

    void Update()
    {
        FollowPlayer();
    }

    public void TakeDamage(float damageAmount)
    {
        CurrentHealth -= damageAmount;

        healthBar.UpdateHealth(currenthHealth / maxHealth);

        if (CurrentHealth <= 0f)
        {
            Die();
        }
    }
    // Inheritance -- This method will be inherited by all classes extending Enemy class
    void Die()
    {
        Destroy(gameObject);
    }

    // Inheritance -- This method will be inherited by all classes extending Enemy class
    protected void FollowPlayer()
    {
        if (player != null)
        {
            enemyMeshAgent.SetDestination(player.transform.position);
            if (!enemyMeshAgent.pathPending)
            {
                if (enemyMeshAgent.remainingDistance <= enemyMeshAgent.stoppingDistance)
                {
                    animator.SetBool("isFollowingPlayer", false);
                    animator.SetBool("isIdle", true);
                    enemyMeshAgent.velocity = Vector3.zero;
                    if (!enemyMeshAgent.hasPath || enemyMeshAgent.velocity.sqrMagnitude == 0f)
                    {
                        Quaternion lookRotation = Quaternion.LookRotation(player.transform.position - transform.position);
                        Vector3 rotation = lookRotation.eulerAngles;
                        enemyMeshAgent.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
                    }
                }
                else
                {
                    animator.SetBool("isFollowingPlayer", true);
                    animator.SetBool("isIdle", false);
                }
            }

            // if (enemy.remainingDistance <= 3 && Time.time >= nextTimeToHit)
            // {
            //     nextTimeToHit = Time.time + 1f / hitRate;
            //     HitPlayer(player);
            // }
        }
    }

    protected void HitPlayer(GameObject player)
    {
        PlayerController playerController = player.GetComponent<PlayerController>();
        if (playerController != null)
            playerController.TakeDamage(damage);
    }
    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            if (playerController != null)
                playerController.TakeDamage(damage);
        }
    }

}
