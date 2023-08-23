using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelStats : MonoBehaviour
{

    private float maxValue;
    private float minValue;
  
    [SerializeField] Slider slider;

    [SerializeField] TextMeshProUGUI progressText;
    

    float newGameProgressValue = 0;
    private float currentValue;
    // Start is called before the first frame update
    void Start()
    {
        
        currentValue = newGameProgressValue;

        minValue = slider.minValue;
        maxValue = slider.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        progressText.text = currentValue.ToString() + "%";
    }

    public void UpdateProgressBar(float value)
    {
        currentValue += value;

        if (currentValue > maxValue)
        {
            currentValue = maxValue;
        }

        if(currentValue < minValue)
        {
            currentValue = minValue;
        }

        slider.value = currentValue;
    }
}
