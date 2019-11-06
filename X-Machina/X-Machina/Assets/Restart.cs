using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    

    public void Onclick()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
        AmmoText.ammoAmount = 100;
    }
   
   
}
