using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public static class SwitchCamera 
{
    static List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();

    public static CinemachineVirtualCamera active_camera = null;

    public static bool IsActiveCamera(CinemachineVirtualCamera camera) 
    {
        return camera == active_camera;
    }

    public static void SwitchingCamera(CinemachineVirtualCamera camera) 
    {
        camera.Priority = 10;
        active_camera = camera;

        foreach(CinemachineVirtualCamera c in cameras) 
        {
            if (c != camera && c.Priority != 0) 
            {
                c.Priority = 0;
            }
        }
    }
    public static void Register(CinemachineVirtualCamera camera) 
    {
        cameras.Add(camera);

     //   Debug.Log("Camera Registered: " + camera);
    }

    public static void Unregister(CinemachineVirtualCamera camera)
    {
        cameras.Remove(camera);
       // Debug.Log("Camera unregistered: " + camera);

    }
}
