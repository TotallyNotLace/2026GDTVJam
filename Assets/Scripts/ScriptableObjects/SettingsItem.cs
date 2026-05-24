using UnityEngine;

[CreateAssetMenu(
fileName = "New Settings",
menuName = "Menu/Settings")]
public class SettingsItem : ScriptableObject
{
    [SerializeField] public string musicVolumeKey;
    [SerializeField] public float musicVolumeSetting;

    [SerializeField] public string voiceVolumeKey;
    [SerializeField] public float voiceVolumeSetting;

    [SerializeField] public string soundEffectVolumeKey;
    [SerializeField] public float soundEffectVolumeSetting;

}
