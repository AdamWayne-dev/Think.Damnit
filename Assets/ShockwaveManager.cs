using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveManager : MonoBehaviour
{
    [SerializeField] private float shockwaveTime = 0.75f;

    private Coroutine shockwaveCoroutine;

    private Material mat;

    private static int waveDistanceFromCentre = Shader.PropertyToID("_WaveDistanceFromCentre");

    private void Awake()
    {
        mat = GetComponent<SpriteRenderer>().material;
    }

    
    public void CallShockwave()
    {
        shockwaveCoroutine = StartCoroutine(ShockWaveStart(-0.1f, 1f));
    }

    private IEnumerator ShockWaveStart(float startPos, float endPos)
    {
        mat.SetFloat(waveDistanceFromCentre, startPos);

        float lerpedAmount = 0f;

        float elapsedTime = 0f;
        while(elapsedTime < shockwaveTime)
        {
            elapsedTime += Time.deltaTime;

            lerpedAmount = Mathf.Lerp(startPos, endPos, (elapsedTime / shockwaveTime));
            mat.SetFloat(waveDistanceFromCentre, lerpedAmount);
            yield return null;
        }
    }
    

    
}
