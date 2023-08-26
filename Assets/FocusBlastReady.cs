using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FocusBlastReady : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    LevelStats stats;
    float focusLevel;
    // Start is called before the first frame update
    void Start()
    {
        stats = FindAnyObjectByType<LevelStats>();
        text.alpha = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        focusLevel = stats.GetFocusLevel();

        if (focusLevel >= 100)
        {
            text.alpha = 1f;
        }

        else 
        {
            text.alpha = 0f;
        }
    }
}
