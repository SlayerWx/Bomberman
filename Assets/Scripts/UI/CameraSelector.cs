using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraSelector : MonoBehaviour
{
    [SerializeField]
    Camera[] cameras;
    [SerializeField]
    ChangeCamera player;
    void Start()//asAS
    {
        player.SetCantCameras(cameras.Length);
        ClearCameras();
        cameras[0].enabled = true;
    }

    public void ChangingCam()
    {
        ClearCameras();
        cameras[player.GetCamerasSelection()].enabled = true;
    }
    void ClearCameras()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].enabled = false;
        }
    }
}
