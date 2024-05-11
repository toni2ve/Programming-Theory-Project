
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField]
    protected Transform cameraTransform;
    [SerializeField]
    protected float fireRate = 1.0f;
    protected float damage = 1.0f;
    protected float nextTimeToFire = 0f;

    // Update is called once per frame
    protected virtual void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            Debug.Log("Fire");
            nextTimeToFire = Time.time + 1f / fireRate;
            FireWeapon();
        }
    }
    protected virtual void FireWeapon()
    {
    }
}
