using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsaneModeTracker : MonoBehaviour
{
    
     private static bool insaneModeActive;
    void Start()
    {
        
        DontDestroyOnLoad(gameObject);
    }

   
    public void SetInsaneStatus()
    {
        insaneModeActive = !insaneModeActive;
        Debug.Log(insaneModeActive);
    }

    public bool GetInsaneStatus()
    {
        return insaneModeActive;
    }
}
