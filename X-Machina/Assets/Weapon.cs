using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float distance = 0.8f;
    public int maxGrenadeCount = 3; //maximum of grenade he can hold.
    public int grenadeCount;
    public GameObject grenadeMod;
    private GameObject grenade;
    private GameObject[] grenadeArr;
    private int activeGrenadeCount = 0;
    public bool grenadeActive;
    public Animator recoileffect;

    void Start()
    {
        grenadeCount = maxGrenadeCount;
        grenadeActive = false;
        grenadeArr = new GameObject[maxGrenadeCount];
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
            //Granade();
            GrenadeAmmo.ammoAmount -= 1;
            //Instantiate(grenadeMod, firePoint.position, firePoint.rotation);
            grenade = Instantiate(grenadeMod, firePoint.position, firePoint.rotation);
            grenadeArr[activeGrenadeCount] = grenade;
            activeGrenadeCount += 1;
            grenadeCount -= 1;
            grenadeActive = true;
        }

        if(Input.GetKeyDown(KeyCode.T))
        {
            //grenade.GetComponent<Grenade>().SuicideBombing();
            foreach (GameObject g in grenadeArr)
            {
                if(g.activeSelf)
                    g.GetComponent<Grenade>().SuicideBombing();
            }
        }
    }

    void Shoot()
    {
        AmmoText.ammoAmount -= 1;
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void Granade()
    {
        GrenadeAmmo.ammoAmount -= 1;
        Instantiate(grenadeMod, firePoint.position, firePoint.rotation);
        grenadeCount -= 1;
    }


}
