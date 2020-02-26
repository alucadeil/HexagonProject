using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    
    public AudioMixer audioMixer;
    public Dropdown dropdown;
    public Slider slider;

    void Awake()
    {
            dropdown.value = PlayerPrefs.GetInt("CurrentGraphics"); 
            slider.value = PlayerPrefs.GetFloat("CurrentVolume");
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("CurrentVolume", volume);
    }

    public void SetQuality(int qualityIndex)
    {

        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("CurrentGraphics", qualityIndex);
    }

}
