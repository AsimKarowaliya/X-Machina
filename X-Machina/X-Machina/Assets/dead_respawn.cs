using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dead_respawn : MonoBehaviour
{
    public GameObject gameoverMenu;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0;
            gameoverMenu.SetActive(true);
        }
    }
}
