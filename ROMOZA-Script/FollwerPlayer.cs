using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollwerPlayer : MonoBehaviour
{
    private GameObject aplayer;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    void Update()
    {
        if(!aplayer)
        {
            aplayer = GameObject.FindWithTag("Player");
        }
        //transform.position = aplayer.transform.position + new Vector3(-12.5f, 21.9f, 30.8f);
        Vector3 desiredPosition = aplayer.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position,desiredPosition,smoothSpeed);
        transform.position = smoothedPosition;
    }
}
