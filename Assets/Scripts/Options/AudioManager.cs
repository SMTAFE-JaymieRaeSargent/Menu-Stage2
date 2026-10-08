using UnityEngine; // Unity
using UnityEngine.Audio; // Audio Mixer 
using UnityEngine.UI; // UI elements
using TMPro;

public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    [SerializeField] Slider[] _slider = new Slider[3];
    [SerializeField] TMP_Text[] _percentText = new TMP_Text[3];
    [SerializeField] float[] _volume = new float[3];
    [SerializeField] string[] _channelName = new string[3];

    public float[] VolumeControl
    {
        set
        {
            _volume = value;
        }
        get
        {
            return _volume;
        }
    }

    public void ChangeVolume(int volumeID)
    {
        VolumeControl[volumeID] = _slider[volumeID].value;
        audioMixer.SetFloat(_channelName[volumeID], VolumeControl[volumeID]);
        _percentText[volumeID].text = $"{Mathf.Clamp01((VolumeControl[volumeID] + 80)/100):P0}";
    }

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            _slider[i].value = VolumeControl[i];
            audioMixer.SetFloat(_channelName[i], VolumeControl[i]);
            _percentText[i].text = $"{Mathf.Clamp01((VolumeControl[i] + 80) / 100):P0}";
        }
    }

}
