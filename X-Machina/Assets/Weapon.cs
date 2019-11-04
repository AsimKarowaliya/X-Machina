using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float distance = 0.8f;
    public float maxGrenadeCount = 3; //maximum of grenade he can hold.
    public float grenadeCount;
    public GameObject grenadeMod;
    public bool grenadeActive;
    public Animator recoileffect;

    void Start()
    {
        grenadeCount = maxGrenadeCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && AmmoText.ammoAmount > 0)
        {
            Shoot();
            recoileffect.SetBool("recoil", true);
        }
        else
        {
            recoileffect.SetBool("recoil", false);
        }

        //throwing grenade.
        if (Input.GetKeyDown(KeyCode.G) && grenadeCount > 0)
        {
            Granade();
            grenadeActive = true;
        }

        if (grenadeMod.activeSelf) grenadeActive = true;
        else if (!grenadeMod.activeSelf) grenadeActive = false;
    }

    void Shoot()
    {
        AmmoText.ammoAmount -= 1;
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void Granade()
    {
        grenadeCount -= 1;
        Instantiate(grenadeMod, firePoint.position, firePoint.rotation);
    }


}
