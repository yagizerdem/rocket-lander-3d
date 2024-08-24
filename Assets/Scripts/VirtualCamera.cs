using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualCamera : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachineCamera;
    CinemachineFramingTransposer cinemachineFramingTransposer;
    private float cameraDistance = 10f;
    void Start()
    {
        this.cinemachineCamera = GetComponent<CinemachineVirtualCamera>();
        cinemachineFramingTransposer = cinemachineCamera.GetCinemachineComponent<CinemachineFramingTransposer>();

        cinemachineFramingTransposer.m_CameraDistance = cameraDistance;
        cinemachineCamera.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        CinemachineComposer composer = cinemachineCamera.GetCinemachineComponent<CinemachineComposer>();

        composer.m_ScreenX = 0.5f;
        composer.m_ScreenY = 0.5f;

        composer.m_DeadZoneWidth = 0f;
        composer.m_DeadZoneHeight = 0f;
    }
}
