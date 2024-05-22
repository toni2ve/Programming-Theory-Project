
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField]
    protected Transform cameraTransform;
    [SerializeField]
    private float fireRate;
    private float damage;
    private float maxHitDistance;
    private int clipSize;
    private int clipAmmo;
    private int extraAmmo;
    private int maxAmmo;
    private bool reloading;

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
            _nextTimeToFire = Time.time + 1f / FireRate;
            FireWeapon();
        }
    }
    // Abstract method
    protected virtual void FireWeapon()
    {
    }
    // Abstract method
    public virtual void ReloadWeapon()
    {
    }

    protected void UpdateClipAmmoDisplay(int value)
    {
        GameManager.Instance.UpdateClipAmmoDisplay(value);
    }
    protected void UpdateExtraAmmoDisplay(int value)
    {
        GameManager.Instance.UpdateExtraAmmoDisplay(value);
    }

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

    public float MaxHitDistance
    {
        get { return maxHitDistance; }
        protected set  // Encapsulation -- Only Inherited classes can set the value
        {
            if (value < 1)
                value = 100.0f;

            maxHitDistance = value;
        }
    }

    public int ClipAmmo
    {
        get { return clipAmmo; }
        protected set
        {
            if (value < 1)
                value = 0;
            clipAmmo = value;
        }
    }
    public int ClipSize
    {
        get { return clipSize; }
        protected set
        {
            clipSize = value;
        }
    }

    public int MaxAmmo
    {
        get { return maxAmmo; }
        protected set
        {
            maxAmmo = value;
        }
    }

    public int ExtraAmmo
    {
        get { return extraAmmo; }
        protected set
        {
            if (value < 0)
                value = 0;
            extraAmmo = value;
        }
    }

    public bool Reloading
    {
        get { return reloading; }
        protected set
        {
            reloading = value;
        }
    }
}
