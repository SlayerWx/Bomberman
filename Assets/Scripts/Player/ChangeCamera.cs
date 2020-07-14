using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ChangeCamera : MonoBehaviour
{
    int myCameraSelection;
    int cantCameras;
    const int limitCameras = 10; //No Change
    public delegate void ChangeMyCamera();
    public static event ChangeMyCamera playerChangeCamera;
    void Start()
    {
        cantCameras = 0;
        myCameraSelection = 1;
        playerChangeCamera += WantCameraChange;
    }
    void Update()
    {
        CameraSelection();
    }
    void CameraSelection()
    {
        for (int i = 0; i < cantCameras; i++)
        {
            if (Input.GetKeyDown(KeyCode.Keypad0+i) && i < limitCameras)
            {
                SetCamera(i);
            }
        }
    }
    void SetCamera(int i)
    {
        myCameraSelection = i;
    }
    public int GetCamerasSelection()
    {
        if (myCameraSelection != 0) return myCameraSelection;
        else return limitCameras;
    }
    public void SetCantCameras(int i)
    {
        cantCameras = i;
    }
    public void WantCameraChange()
    {

    }
}