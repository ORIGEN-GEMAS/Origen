using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("--------- Audio Source ------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--------- Audio Clip ------------")]
    public AudioClip redWorld;
    public AudioClip menu;
    public AudioClip click;
    public AudioClip walking;
    public AudioClip jump;
    public AudioClip forestWorld;
    public AudioClip death;
    public AudioClip takeGems;

    /*private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }*/

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Red World")
        {
            musicSource.Pause();
            musicSource.clip = redWorld;
            musicSource.Play();
        }
}

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.Pause();
        musicSource.clip = clip;
        musicSource.Play();
    }
}