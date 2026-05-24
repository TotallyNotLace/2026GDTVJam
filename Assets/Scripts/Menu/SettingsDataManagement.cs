using UnityEngine;
using UnityEngine.Events;

public class SettingsDataManagement : MonoBehaviour
{
    [SerializeField] private SettingsItem settings;

    [SerializeField] private UnityEvent loadComplete;

    public void LoadSettings()
    {
        settings.musicVolumeSetting = PlayerPrefs.GetFloat(settings.musicVolumeKey);
        settings.voiceVolumeSetting = PlayerPrefs.GetFloat(settings.voiceVolumeKey);
        settings.soundEffectVolumeSetting = PlayerPrefs.GetFloat(settings.soundEffectVolumeKey);
        loadComplete?.Invoke();
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat(settings.musicVolumeKey, settings.musicVolumeSetting);
        PlayerPrefs.SetFloat(settings.voiceVolumeKey, settings.voiceVolumeSetting);
        PlayerPrefs.SetFloat(settings.soundEffectVolumeKey, settings.soundEffectVolumeSetting);
    }
}
