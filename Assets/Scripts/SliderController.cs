using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderController : MonoBehaviour
{
    public TMP_Text valueText;
    public Slider slider;
        
    public void OnSliderChanged(float value) 
    { 
        valueText.text = value.ToString() + " %";
    }

    
   
}
