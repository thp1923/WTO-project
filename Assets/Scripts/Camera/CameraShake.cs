using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;
    public CinemachineVirtualCamera vcam;
    
    void Awake()
    {
        Instance = this;
    }
    
    public void ShakeCamera(float intensity, float time)
    {
        var noise = vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        noise.m_AmplitudeGain = intensity;
        noise.m_FrequencyGain = 10;
        // gọi hàm StopShake sau time giây
        Invoke(nameof(StopShake), time);
    }
    
    void StopShake()
    {
        var noise = vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        noise.m_AmplitudeGain = 0;
    }
}
