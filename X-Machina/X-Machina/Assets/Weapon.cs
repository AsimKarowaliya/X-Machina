using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject Ulti;
    public float distance = 0.8f;
    public int maxGrenadeCount; //maximum of grenade he can hold.
    public int grenadeCount = 0;
    public GameObject grenadeMod;
    private GameObject grenade;
    private GameObject[] grenadeArr;
    public int maxActiveGrenade;
    public int activeGrenadeCount = 0;
    public Animator recoileffect;
  
    void Start()
    {
        grenadeCount = maxGrenadeCount;
        grenadeArr = new GameObject[maxGrenadeCount];
      
    }

    // Update is called once per frame
    void Update()
    {
        GameObject ultsomthing = GameObject.FindGameObjectWithTag("ulttag");
        Ultimate u = ultsomthing.GetComponent<Ultimate>();

        
        if (Input.GetButtonDown("Fire1") && AmmoText.ammoAmount > 0)
        {
            Shoot();
            recoileffect.SetBool("recoil", true);
        }
        else if(Input.GetKeyDown(KeyCode.R) && u.Ult >= 0.3f)
        {
            ShootUlitmate();
            recoileffect.SetBool("recoil", true);
        }
        else
        {
            recoileffect.SetBool("recoil", false);
        }

        //throwing grenade.
        if (Input.GetKeyDown(KeyCode.G) && grenadeCount > 0 && activeGrenadeCount < maxActiveGrenade)
        {
            grenade = Instantiate(grenadeMod, firePoint.position, firePoint.rotation);
            grenadeArr[activeGrenadeCount] = grenade;
            activeGrenadeCount += 1;
            grenadeCount -= 1;
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
        }
    }

    void Shoot()
    {
        AmmoText.ammoAmount -= 1;
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void ShootUlitmate()
    {
        GameObject ultsomthing = GameObject.FindGameObjectWithTag("ulttag");
        Ultimate u = ultsomthing.GetComponent<Ultimate>();
        Instantiate(Ulti, firePoint.position, firePoint.rotation);
        u.Ult = 0;
       
    }

    //void Granade()
    //{
    //    GrenadeAmmo.ammoAmount -= 1;
    //    Instantiate(grenadeMod, firePoint.position, firePoint.rotation);
    //    grenadeCount -= 1;
    //}


}
