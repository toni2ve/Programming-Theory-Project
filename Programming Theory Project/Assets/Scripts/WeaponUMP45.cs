using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUMP45 : Weapon
{

    [SerializeField]
    private ParticleSystem muzzleFlash;
    AudioSource _shootingSound;

    // Polymorphism -- implementation of abstract method
    protected override void Start()
    {
        Damage = 5.0f;
        FireRate = 10.0f;
        MaxHitDistance = 200.0f;
        _shootingSound = GetComponent<AudioSource>();
    }

    // Polymorphism -- implementation of abstract method
    protected override void FireWeapon()
    {
        if (!muzzleFlash.isPlaying)
            muzzleFlash.Play();
        if (_shootingSound != null)
            _shootingSound.Play();
        RaycastHit hit;
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, MaxHitDistance))
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(Damage);
            }
        }
    }
}
