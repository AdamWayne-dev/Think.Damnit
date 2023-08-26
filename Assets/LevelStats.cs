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

    private float maxFocusValue;
    private float minFocusValue;

    [SerializeField] Slider slider;
    [SerializeField] Slider focusSlider;

    [SerializeField] TextMeshProUGUI progressText;
    [SerializeField] TextMeshProUGUI focusText;

    [SerializeField] Canvas optionsCanvas;
    
    LevelManager levelManager;

    float newGameProgressValue = 10;
    private float currentValue;
    private float currentFocusValue;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GetComponent<LevelManager>();
        currentValue = newGameProgressValue;
        currentFocusValue = 0;

        minValue = slider.minValue;
        maxValue = slider.maxValue;
        minFocusValue = focusSlider.minValue;
        maxFocusValue = focusSlider.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        progressText.text = currentValue.ToString() + "%";
        focusText.text = currentFocusValue.ToString() + "%";

        if(currentValue <= 0)
        {
            levelManager.LoadLose();
        }

        if(currentValue >= 100)
        {
            levelManager.LoadWin();
        }

        ShowOptions();
    }

    public void ShowOptions()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            optionsCanvas.gameObject.SetActive(true);
            if(optionsCanvas.enabled)
            {
                Time.timeScale = 0f;
            }

            
        }
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

    public void UpdateFocusBar(float value)
    {
        currentFocusValue += value;

        if (currentFocusValue > maxFocusValue)
        {
            currentFocusValue = maxFocusValue;
        }

        if (currentFocusValue < minFocusValue)
        {
            currentFocusValue = minFocusValue;
        }

        focusSlider.value = currentFocusValue;
    }

    public void ResetFocus()
    {
        currentFocusValue = minFocusValue;
        focusSlider.value = currentFocusValue;
    }

    public float GetFocusLevel()
    {
        return focusSlider.value;
    }
}
