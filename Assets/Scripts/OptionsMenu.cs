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
        if (PlayerPrefs.HasKey("Volume"))
        {
            slider.value = PlayerPrefs.GetFloat("Volume");
        } else slider.value = 1f;
        if (PlayerPrefs.HasKey("CurrentGraphics"))
        {
            dropdown.value = PlayerPrefs.GetInt("CurrentGraphics"); 
        } else dropdown.value = 2;
            
        
        
    }

    public void SetVolume(float volume)
    {
        if(volume == 0.001f)
        {
            audioMixer.SetFloat("Volume", -100);
            PlayerPrefs.SetFloat("Volume", volume);

        }else 
        {
            audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
            PlayerPrefs.SetFloat("Volume", volume);
        }
    }

    public void SetQuality(int qualityIndex)
    {

        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("CurrentGraphics", qualityIndex);
    }

}
