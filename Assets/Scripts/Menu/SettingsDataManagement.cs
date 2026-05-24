using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SettingsDataManagement : MonoBehaviour
{
    [SerializeField] private SettingsItem settings;

    [SerializeField] private UnityEvent loadComplete;

    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider voiceVolume;
    [SerializeField] private Slider effectVolume;

    public void LoadSettings()
    {
        settings.musicVolumeSetting = PlayerPrefs.GetFloat(settings.musicVolumeKey);
        settings.voiceVolumeSetting = PlayerPrefs.GetFloat(settings.voiceVolumeKey);
        settings.soundEffectVolumeSetting = PlayerPrefs.GetFloat(settings.soundEffectVolumeKey);

        musicSlider.value = settings.musicVolumeSetting;
        voiceVolume.value = settings.voiceVolumeSetting;
        effectVolume.value = settings.soundEffectVolumeSetting;

        loadComplete?.Invoke();
    }

    public void SaveSettings()
    {
        settings.musicVolumeSetting = musicSlider.value;
        settings.voiceVolumeSetting = voiceVolume.value;
        settings.soundEffectVolumeSetting = effectVolume.value;
        
        PlayerPrefs.SetFloat(settings.musicVolumeKey, settings.musicVolumeSetting);
        PlayerPrefs.SetFloat(settings.voiceVolumeKey, settings.voiceVolumeSetting);
        PlayerPrefs.SetFloat(settings.soundEffectVolumeKey, settings.soundEffectVolumeSetting);
    }


}
