using System;
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
    private float damage;
    protected float nextTimeToHit = 0f;
    protected int scorePoint;
    NavMeshAgent enemyMeshAgent = null;
    Animator animator = null;
    GameObject player = null;
    PlayerController playerController = null;

    protected Boolean isDead = false;

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
    public int ScorePoint
    {
        get { return scorePoint; }
        protected set   // Encapsulation -- Only Inherited classes can set the value
        {
            scorePoint = value;
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
        playerController = player.GetComponent<PlayerController>();
        animator.SetBool("isIdle", true);
        animator.SetBool("isFollowingPlayer", false);
    }

    void Update()
    {
        if (!isDead)
            FollowPlayer(); //Abstraction
    }

    public void TakeDamage(float damageAmount)
    {
        CurrentHealth -= damageAmount;

        healthBar.UpdateHealth(currenthHealth / maxHealth);

        if (CurrentHealth <= 0f)
        {
            Die(); //Abstraction
        }
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
                    HitPlayer();
                }
                else
                {
                    animator.SetBool("isFollowingPlayer", true);
                    animator.SetBool("isIdle", false);
                    animator.SetBool("Attack", false);
                }
            }
        }
    }

    // Inheritance -- This method will be inherited by all classes extending Enemy class
    void Die()
    {
        isDead = true;
        if (GameManager.Instance != null)
        {
            GameManager.Instance.currentPlayerData.Highscore += ScorePoint;
            GameManager.Instance.UpdatePlayerHighscore();
        }
        enemyMeshAgent.SetDestination(transform.position);
        enemyMeshAgent.velocity = Vector3.zero;
        animator.SetBool("Dead", true);
        BoxCollider[] colliders = gameObject.GetComponentsInChildren<BoxCollider>();
        foreach (BoxCollider collider in colliders)
        {
            collider.enabled = false;
        }
        Destroy(gameObject, 3.0f);
    }
    protected void HitPlayer()
    {
        animator.SetBool("Attack", true);
    }
}
