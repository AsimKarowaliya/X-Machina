using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackgroundMovement : MonoBehaviour
{
    [SerializeField]
    private Transform mainCameraPosition;

    [SerializeField]
    private float backgroundMoveSpeed;
    private float directionX;

    [SerializeField]
    private float offsetByX = 13f;


    // Update is called once per frame
    void Update()
    {
        directionX = Input.GetAxis("Horizontal") * backgroundMoveSpeed * Time.deltaTime;

        transform.position = new Vector3(transform.position.x + directionX, transform.position.y, 
            transform.position.z);
        
        if(transform.position.x - mainCameraPosition.position.x < -offsetByX)
        {
            transform.position = new Vector3(mainCameraPosition.position.x + offsetByX,
                transform.position.y, transform.position.z);
        }

        else if(transform.position.x - mainCameraPosition.position.x > offsetByX)
        {
            transform.position = new Vector3(mainCameraPosition.position.x - offsetByX,
                transform.position.y, transform.position.z);
        }

    }
}
