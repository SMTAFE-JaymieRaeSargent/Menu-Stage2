using UnityEngine;
using TMPro;
public class QualityManager : MonoBehaviour
{
    [SerializeField] TMP_Dropdown _qualityDropdown;
    int _currentQualityIndex = 0;

    public int CurrentQualityIndex
    {
        set
        {
            _currentQualityIndex = value;
        }
        get
        {
            return _currentQualityIndex;
        }
    }

    public void ChangeQuality(int qualityIndex)
    {
        CurrentQualityIndex = qualityIndex;
        QualitySettings.SetQualityLevel(CurrentQualityIndex);
    }
    void Start()
    {
        _qualityDropdown.value = CurrentQualityIndex;
        QualitySettings.SetQualityLevel(CurrentQualityIndex);
    }
}
