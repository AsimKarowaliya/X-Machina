using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{

    public int playerHealth;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite emptyHearts;

    public GameObject gameoverMenu;
    void Update()
    {

        if (playerHealth > numOfHearts)
        {
            playerHealth = numOfHearts;

        }

        /** if (//if player health changes from previous health then){
                     
                  GetComponent<SpriteRenderer>().color = Color.red;
             Invoke("ResetMat", 0.2f);
            
                 }**/

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < playerHealth)
            {
                hearts[i].sprite = fullHearts;
            }
            else
            {
                hearts[i].sprite = emptyHearts;
            }

            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        if(playerHealth == 0)
        {
            Destroy(gameObject);
            Time.timeScale = 0;
            gameoverMenu.SetActive(true);
            //Death effect
            //Invoke end screen function after few seconds 
            
        }

    }

}
