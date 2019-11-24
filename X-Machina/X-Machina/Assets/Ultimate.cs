using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ultimate : MonoBehaviour
{
    Image Ultimates;
    float maxUlt = 0f;
    public static float Ult;
    // Start is called before the first frame update
    void Start()
    {
        Ultimates = GetComponent<Image>();
        Ult = maxUlt;
      
    }

    // Update is called once per frame
    void Update()
    {
        Ultimates.fillAmount = Ult;
    }
}
