using UnityEngine;

public class MusicManager : MonoBehaviour
{
    static public MusicManager Instance;
    public AudioClip shelterMusic;
    public AudioClip cheeseMusic;
    private AudioSource audioSource;

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
            audioSource.volume = 0.5f;
        else
            audioSource.volume = 0.9f;
        audioSource.clip = newClip;
        audioSource.Play();
    }

    public void PlayCheeseMusic() => PlayMusic(cheeseMusic);
    public void PlayShelterMusic() => PlayMusic(shelterMusic);
}
