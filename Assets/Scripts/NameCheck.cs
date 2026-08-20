using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NameCheck : MonoBehaviour
{
    public TMP_InputField nameField;
    public GameSaveAndLoad saveAndLoadData;

    public void CheckName(Button playButton)
    {
        if (!string.IsNullOrEmpty(nameField.text))
        {
            playButton.interactable = true;
        }
        else
        {
            playButton.interactable = false;
        }
    }

    public void SendData()
    {
        saveAndLoadData.data.name = nameField.text;
    }
}
