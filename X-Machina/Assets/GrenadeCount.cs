using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeCount : MonoBehaviour
{
     Text text;
    public static int ammoAmount = 3;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ammoAmount > 0)
        {
            text.text = "X " + ammoAmount;
        }else
        {
            text.text = "0";
        }
    }
}
