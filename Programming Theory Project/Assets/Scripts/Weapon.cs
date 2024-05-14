
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField]
    protected Transform cameraTransform;
    [SerializeField]
    private float fireRate;
    private float damage;
    public float FireRate
    {
        get { return fireRate; }
        protected set  // Encapsulation -- Only Inherited classes can set the value
        {
            if (value < 1)
                value = 1.0f;
            fireRate = value;
        }
    }

    public float Damage
    {
        get { return damage; }
        protected set  // Encapsulation -- Only Inherited classes can set the value
        {
            if (value < 1)
                value = 1.0f;

            damage = value;
        }
    }

    protected float _nextTimeToFire = 0f;

    // Abstract Start method
    protected virtual void Start()
    {
    }

    // Update is called once per frame
    protected void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= _nextTimeToFire)
        {
            Debug.Log("Fire");
            _nextTimeToFire = Time.time + 1f / FireRate;
            FireWeapon();
        }
    }
    // Abstract method
    protected virtual void FireWeapon()
    {
    }
}
