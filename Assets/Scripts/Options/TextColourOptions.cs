using UnityEngine;
using UnityEngine.UI;

public class TextColourOptions : MonoBehaviour
{
    float r, g, b, size;
    public Image display;

    public Slider red, green, blue, sizeSlider;

    private void Start()
    {

        Setup();
    }
    void Setup()
    {
        Color32 newColour = ModifyText.instance.fontInfo.color;
        display.color = newColour;
        red.value = newColour.r;
        green.value = newColour.g;
        blue.value = newColour.b;
        size = ModifyText.instance.fontInfo.scale;
        sizeSlider.value = size;
    }

    public void OnSliderChangeRed(float value)
    {
        r = value;
    }
    public void OnSliderChangeGreen(float value)
    {
        g = value;
    }
    public void OnSliderChangeBlue(float value)
    {
        b = value;
    }
    public void OnSliderChangeScale(float value)
    {
        size = value;
    }
    public void UpdateImageAndColour()
    {
         Color32 updatedColour = new Color32((byte)r, (byte)g, (byte)b,255);
        display.color = updatedColour;   
    }
    public void ApplyChanges()
    {
        Color32 updatedColour = new Color32((byte)r, (byte)g, (byte)b, 255);
        ModifyText.instance.fontInfo.color = updatedColour;
        ModifyText.instance.fontInfo.scale = size;
        ModifyText.instance.UpdateAllText();
    }
    public void ResetFont()
    {
        ModifyText.instance.ResetUpdateAllText();
        Setup();
    }
}
