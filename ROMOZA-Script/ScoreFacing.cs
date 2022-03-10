using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreFacing : MonoBehaviour
{
    private Transform UICAM;
    void Start()
    {
        UICAM = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + UICAM.rotation * Vector3.forward, UICAM.rotation * Vector3.up);
    }
}
