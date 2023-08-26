using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class CollisionColourFlash : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    [SerializeField] AudioSource audioSource;
    AudioClip audioClip;
    [SerializeField] List<AudioClip> goodAudioClips;
    [SerializeField] List<AudioClip> badAudioClips;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == ("GoodGuy"))
        {
            if(!audioSource.isPlaying) 
            {
                PlayGoodAudio();
            }
            StartCoroutine(FlashGreen());
        }

        if (collision.gameObject.tag == "Enemy")
        {
            if (!audioSource.isPlaying)
            {
                PlayBadAudio();
            }
            StartCoroutine(FlashRed());
        }
    }

    IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;

    }

    IEnumerator FlashGreen()
    {
        spriteRenderer.color = Color.green;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }

    public void PlayGoodAudio()
    {
        audioClip = goodAudioClips[Random.Range(0, goodAudioClips.Count)];
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public void PlayBadAudio() 
    {
        audioClip = badAudioClips[Random.Range(0, badAudioClips.Count)];
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
