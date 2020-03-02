using UnityEngine.Audio;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    private AudioSource backMusic;
    public AudioMixer mixer;
    void Awake()
    {
        backMusic = GetComponent<AudioSource>();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        } else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        mixer.SetFloat("Volume", Mathf.Log10(PlayerPrefs.GetFloat("Volume")) * 20);
    }

    void Update()
    {

        if(GameMenu.gameIsPaused)
        {
            backMusic.volume = 0.3f;
            backMusic.pitch = 0.95f;
        }else 
        {
            backMusic.volume = 0.7f;
            backMusic.pitch = 1f;
        }
    }
}
