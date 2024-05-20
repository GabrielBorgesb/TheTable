using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamerasManager : MonoBehaviour
{
    public static CamerasManager instance;

    public CinemachineVirtualCamera vcamFP;
    public CinemachineVirtualCamera vcamTable;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(instance);
        }else
        {
            instance = this;
        }
    }

    
}
