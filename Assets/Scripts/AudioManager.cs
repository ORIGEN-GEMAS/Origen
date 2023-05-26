using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("--------- Audio Source ------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--------- Audio Clip ------------")]
    public AudioClip gameplay;
    public AudioClip menu;
    public AudioClip click;
    public AudioClip walking;
    public AudioClip jump;
    public AudioClip forestWorld;
    public AudioClip death;
    public AudioClip takeGems;
    public AudioClip nar1;
    public AudioClip nar2;
    public AudioClip hidraAttack;
    public AudioClip hidraHit;
    public AudioClip hidraDeath;
    public AudioClip irisAttack;

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
        if (SceneManager.GetActiveScene().name == "Inicio")
        {
            musicSource.Pause();
            musicSource.clip = menu;
            musicSource.Play();
        }
        if (SceneManager.GetActiveScene().name == "Red World"|| SceneManager.GetActiveScene().name == "born"|| SceneManager.GetActiveScene().name == "HidraCombat")
        {
            musicSource.Pause();
            musicSource.clip = gameplay;
            musicSource.Play();
        }
        if (SceneManager.GetActiveScene().name == "born")
        {
            PlaySFX(nar1);
        }
        if (SceneManager.GetActiveScene().name == "Forest")
        {
            musicSource.Pause();
            musicSource.clip = forestWorld;
            musicSource.Play();
        }
        if (SceneManager.GetActiveScene().name == "moiras")
        {
            musicSource.Pause();
            musicSource.clip = gameplay;
            musicSource.Play();
            PlaySFX(nar2);
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