using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float distance = 0.8f;
    public int maxGrenadeCount; //maximum of grenade he can hold.
    public static int grenadeCount;
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
        if (Input.GetKeyDown(KeyCode.G) && GrenadeAmmo.ammoAmount > 0 /*&& !grenadeActive*/)
        {
            grenade = Instantiate(grenadeMod, firePoint.position, firePoint.rotation);
            GrenadeAmmo.ammoAmount -= 1;
            grenadeArr[activeGrenadeCount] = grenade;
            activeGrenadeCount += 1;
            grenadeCount -= 1;
            grenadeActive = true;
        }else if(Input.GetKeyDown(KeyCode.G) && GrenadeAmmo.ammoAmount == 0)
        {

        }

        if(Input.GetKeyDown(KeyCode.T))
        {
            for(int i = 0; i < activeGrenadeCount; i++)
            {
                if(grenadeArr[i] != null)
                {
                    Grenade g = grenadeArr[i].GetComponent<Grenade>();
                    if (gameObject.GetComponent<CharacterController2D>().facingRight())
                    {
                        g.GoRight();
                        g.SuicideBombing();
                    }
                    else
                    {
                        g.GoLeft();
                        g.SuicideBombing();
                    }
                    grenadeArr[i] = null;
                }
            }
            activeGrenadeCount = 0;
        }
    }

    void Shoot()
    {
        AmmoText.ammoAmount -= 1;
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    //void Granade()
    //{
    //    GrenadeAmmo.ammoAmount -= 1;
    //    Instantiate(grenadeMod, firePoint.position, firePoint.rotation);
    //    grenadeCount -= 1;
    //}


}
