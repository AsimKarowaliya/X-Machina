using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Resume : MonoBehaviour
{
    public GameObject pauseMenu;
    public void Onclick()
    {


         pauseMenu.SetActive(false);
            Time.timeScale = 1;

        
       
    }
}
