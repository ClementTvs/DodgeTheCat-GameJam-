using UnityEngine;

public class MusicManager : MonoBehaviour
{
    static public MusicManager Instance;
    public AudioClip shelterMusic;
    public AudioClip cheeseMusic;
    private AudioSource audioSource;

    void Update()
    {
        if (Follow.timeElapsed >= 60f && Follow.timeElapsed < 120)
        {
            audioSource.pitch = 1.04f;
        }
        else if (Follow.timeElapsed >= 120 && Follow.timeElapsed < 180)
        {
            audioSource.pitch = 1.07f;
        }
        else if (Follow.timeElapsed >= 180)
        {
            audioSource.pitch = 1.1f;
        }
        else
            audioSource.pitch = 1f;
    }
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = true;
        if (GameManager.spawnInShelter == true)
            PlayShelterMusic();
        else
            PlayCheeseMusic();
    }

    public void PlayMusic(AudioClip newClip)
    {
        if (audioSource.clip == newClip && audioSource.isPlaying)
            return;

        audioSource.Stop();
        if (cheeseMusic == newClip)
            audioSource.volume = VolumeManager.Instance.audioSource.volume;
        else
            audioSource.volume = VolumeManager.Instance.audioSource.volume;
        audioSource.clip = newClip;
        audioSource.Play();
    }

    public void lowerVolumeMusic()
    {
        audioSource.volume = audioSource.volume / 2;
    }

    public void getBackVolumeMusic()
    {
        audioSource.volume = audioSource.volume * 2;
    }

    public void PlayCheeseMusic() => PlayMusic(cheeseMusic);
    public void PlayShelterMusic() => PlayMusic(shelterMusic);
}
