using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private static AudioPlayer instance;
    [SerializeField] AudioClip music;
    public static AudioPlayer Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AudioPlayer>();
                if (instance == null)
                {
                    GameObject audioPlayerGameObject = new GameObject("AudioPlayerGameObject");
                    instance = audioPlayerGameObject.AddComponent<AudioPlayer>();
                    instance.AudioSource = audioPlayerGameObject.AddComponent<AudioSource>();
                    DontDestroyOnLoad(audioPlayerGameObject);
                }
            }

            return instance;
        }
    }

    public AudioSource AudioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        AudioSource.clip = music;
        AudioSource.loop = true;
        AudioSource.Play();
    }
}