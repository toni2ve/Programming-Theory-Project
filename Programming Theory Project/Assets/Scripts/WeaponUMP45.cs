using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUMP45 : Weapon
{

    [SerializeField]
    private ParticleSystem muzzleFlash;

    [SerializeField]
    private AudioSource _shootingSound;

    [SerializeField]
    private AudioSource _reloadingSound;

    void Awake()
    {
        this.Damage = 5.0f;
        this.FireRate = 10.0f;
        this.MaxHitDistance = 200.0f;
        this.ClipSize = 30;
        this.ClipAmmo = this.ClipSize;
        this.ExtraAmmo = 180;
        this.MaxAmmo = 400;
        this.Reloading = false;
    }

    // Polymorphism -- implementation of abstract method
    protected override void FireWeapon()
    {
        if (this.ClipAmmo > 0)
        {
            if (!muzzleFlash.isPlaying)
                muzzleFlash.Play();
            if (_shootingSound != null)
                _shootingSound.Play();

            this.ClipAmmo -= 1;
            UpdateClipAmmoDisplay(this.ClipAmmo);

            RaycastHit hit;
            if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, MaxHitDistance))
            {
                if (hit.transform.TryGetComponent<Enemy>(out var enemy))
                {
                    enemy.TakeDamage(Damage);
                }
                else if (hit.transform.CompareTag("EnemyPart"))
                {
                    Enemy enemy1 = hit.transform.GetComponentInParent<Enemy>();
                    if (enemy1 != null)
                    {
                        enemy1.TakeDamage(Damage);
                    }
                }
            }
        }
        else
            this.ClipAmmo = 0;
    }

    public override void ReloadWeapon()
    {
        if (!Reloading)
        {
            if (this.ExtraAmmo > 0 && this.ClipAmmo < this.ClipSize)
            {
                Reloading = true;
                StartCoroutine(ReloadAfterAudioClip());
            }
        }
    }

    private IEnumerator ReloadAfterAudioClip()
    {
        if (_reloadingSound != null)
        {
            _reloadingSound.Play();
            yield return new WaitUntil(() => _reloadingSound.time >= _reloadingSound.clip.length);
        }

        int ammoRequired = this.ClipSize - this.ClipAmmo;

        if (this.ExtraAmmo >= ammoRequired)
        {
            this.ClipAmmo += ammoRequired;
            this.ExtraAmmo -= ammoRequired;
        }
        else
        {
            this.ClipAmmo += this.ExtraAmmo;
            this.ExtraAmmo = 0;
        }
        UpdateClipAmmoDisplay(this.ClipAmmo);
        UpdateExtraAmmoDisplay(this.ExtraAmmo);

        Reloading = false;
    }
}
