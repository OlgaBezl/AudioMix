
using UnityEngine;
using UnityEngine.Audio;

public class VolumeAdjuster : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private AudioMixerGroup _mixerGroup;

    private float _minVolumeValue = -80f;
    private float _lastVolumeValue = 0f;
    private float _logVolumeFactor = 20f;
    private bool _isOn = true;

    public void ToggleSound()
    {
        _isOn = !_isOn;

        if (_isOn)
        {
            _mixer.SetFloat(_mixerGroup.name, _lastVolumeValue);
        }
        else
        {
            _mixer.GetFloat(_mixerGroup.name, out _lastVolumeValue);
            _mixer.SetFloat(_mixerGroup.name, _minVolumeValue);
        }
    }

    public void ChangeVolume(float volume)
    {
        float value = volume == 0 ? _minVolumeValue : Mathf.Log10(volume) * _logVolumeFactor;
        _mixer.SetFloat(_mixerGroup.name, value);
    }
}
