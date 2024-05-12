using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUMP45 : Weapon
{

    [SerializeField]
    private ParticleSystem muzzleFlash;
    AudioSource _shootingSound;
    void Start()
    {
        damage = 5.0f;
        fireRate = 15.0f;
        _shootingSound = GetComponent<AudioSource>();
    }

    protected override void FireWeapon()
    {
        if (!muzzleFlash.isPlaying)
            muzzleFlash.Play();
        if (_shootingSound != null)
            _shootingSound.Play();
        RaycastHit hit;
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, 100.0f))
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                Debug.Log(typeof(Enemy));
                enemy.TakeDamage(damage);
            }
        }
    }
}
