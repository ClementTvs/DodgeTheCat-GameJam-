using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    static public VolumeManager Instance;
    public Slider slider;
    public AudioSource audioSource;
    static public float volume;

    void Start()
    {

        Instance = this;
        volume = PlayerPrefs.GetFloat("Volume", 0.5f);
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
        PlayerPrefs.SetFloat("Volume", value);
		PlayerPrefs.Save();
    }
}
