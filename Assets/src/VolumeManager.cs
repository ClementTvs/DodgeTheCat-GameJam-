using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    static public VolumeManager Instance;
    public Slider slider;
    public AudioSource audioSource;
    static private float volume = 0.5f;

    void Start()
    {
        Instance = this;
        slider.value = volume;
        audioSource.volume = volume;

        slider.onValueChanged.AddListener(SetVolume);
        DontDestroyOnLoad(Instance);
        DontDestroyOnLoad(audioSource);

    }

    void SetVolume(float value)
    {
        audioSource.volume = value;
        volume = value;
    }
}
