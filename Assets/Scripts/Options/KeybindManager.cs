using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
public class KeybindManager : MonoBehaviour
{
    [Serializable]
    public struct ActionMapData
    {
        public string actionName;
        public TMP_Text keycodeDisplay;
        public string defaultKey;
    }
    [SerializeField] ActionMapData[] _actionMapData;
    [SerializeField] GameObject _currentSelectedKey;
    public static Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    [SerializeField] Color32 _selectedKey = new Color32(239,116,36,255);
    [SerializeField] Color32 _changedKey = new Color32(39, 171, 249, 255);

    public void ChangeKey(GameObject clickedKey)
    {
        _currentSelectedKey = clickedKey;
        if (_currentSelectedKey != null)
        {
            _currentSelectedKey.GetComponent<Image>().color = _selectedKey;
        }
    }
    void OnGUI()
    {
        Event changeKeyEvent = Event.current;

        if(_currentSelectedKey != null && changeKeyEvent.isKey)
        {
            if(!keys.ContainsValue(changeKeyEvent.keyCode))
            {
                keys[_currentSelectedKey.name] = changeKeyEvent.keyCode;
                _currentSelectedKey.GetComponentInChildren<TMP_Text>().text = changeKeyEvent.keyCode.ToString();
               
               
            }
            _currentSelectedKey.GetComponent<Image>().color = _changedKey;
            _currentSelectedKey = null;
        }
        
    }
    private void Start()
    {
        for (int i = 0; i < _actionMapData.Length; i++)
        {
            if (!keys.ContainsKey(_actionMapData[i].actionName))
            {
                keys.Add(_actionMapData[i].actionName, (KeyCode)Enum.Parse(typeof(KeyCode), _actionMapData[i].defaultKey));
            }
            _actionMapData[i].keycodeDisplay.text = keys[_actionMapData[i].actionName].ToString();
        }
    }
}
