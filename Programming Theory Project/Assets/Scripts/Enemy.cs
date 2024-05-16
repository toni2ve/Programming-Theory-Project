using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private float maxHealth;
    private float currenthHealth;
    public HealthBar healthBar;
    private Color color;
    private float damage;
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

    // Abstract method
    protected virtual void Start()
    {
    }

    void Update()
    {
        FollowPlayer();
    }

    public void TakeDamage(float damageAmount)
    {
        CurrentHealth -= damageAmount;
        
        healthBar.UpdateHealth(currenthHealth/maxHealth);

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
        NavMeshAgent enemy = gameObject.GetComponent<NavMeshAgent>();
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            enemy.SetDestination(player.transform.position);
        }
    }


}
