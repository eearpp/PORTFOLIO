using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class shakeCM : MonoBehaviour
{
    public static shakeCM Instance { get; private set;}

    private CinemachineVirtualCamera CinemachineVirtualCamera;
    private float shakeTime;
    private float shaketimetotal;
    private float startingIntensity;
    private void Awake() 
    {
        Instance = this;
        CinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();   
    }

    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        startingIntensity = intensity;
        shaketimetotal = time ;
        shakeTime = time;
    }

    private void Update() 
    {
        if (shakeTime > 0)
        {
            shakeTime -= Time.deltaTime;

            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain =
                Mathf.Lerp(startingIntensity, 0f, (1-(shakeTime/shaketimetotal)));
            
        }
    }
}
