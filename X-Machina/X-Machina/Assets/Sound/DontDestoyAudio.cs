using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestoyAudio : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
