using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public float pickupRange;
    public Transform player;
    public GameObject AmmoTopText;
    private int availableAmmoCount = 4;
    bool isCoroutineRunning = false;

    [SerializeField]
    private List<GameObject> ammoPacks = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.isGamePaused)
        {
            if (availableAmmoCount == 0 && !isCoroutineRunning)
            {
                isCoroutineRunning = true;
                StartCoroutine(FillAmmoBox());
            }
            Vector3 distanceToPlayer = player.position - transform.position;
            if (distanceToPlayer.magnitude <= pickupRange)
            {
                if (availableAmmoCount <= 0)
                    AmmoTopText.GetComponent<TMP_Text>().text = "Empty";
                else
                    AmmoTopText.GetComponent<TMP_Text>().text = "Press \"E\" to pickup ammo.";

                AmmoTopText.SetActive(true);
                Weapon weapon = player.GetComponentInChildren<Weapon>();

                // show press E to get Ammo
                if (Input.GetKeyDown(KeyCode.E) && weapon != null && !weapon.AmmoFull && availableAmmoCount > 0)
                {
                    PickUpAmmo(weapon);
                }
            }
            else
            {
                AmmoTopText.SetActive(false);
            }
        }
    }

    void PickUpAmmo(Weapon weapon)
    {
        weapon.ExtraAmmo += 30;
        GameManager.Instance.UpdateExtraAmmoDisplay(weapon.ExtraAmmo);
        if (availableAmmoCount > 0)
        {
            availableAmmoCount--;
            ammoPacks[availableAmmoCount].SetActive(false);
        }
    }

    private IEnumerator FillAmmoBox()
    {
        yield return new WaitForSeconds(60);
        foreach (GameObject ammoPack in ammoPacks)
        {
            ammoPack.SetActive(true);
        }
        availableAmmoCount = 4;
        isCoroutineRunning = false;
    }
}
