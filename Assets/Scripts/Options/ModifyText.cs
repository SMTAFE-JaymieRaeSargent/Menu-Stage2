using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ModifyText : MonoBehaviour
{
    public static ModifyText instance;
    public List<TextBase> collectedTexts = new List<TextBase>();
    public FontInfo fontInfo;
    public FontInfo defaultFontInfo;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void ResetUpdateAllText()
    {
        fontInfo.color = defaultFontInfo.color;
        fontInfo.scale = defaultFontInfo.scale;
        RefreshCollectedTextComponents();
        UpdateFont();
    }


    // check if text is already added
    private bool IsAlreadyCollected(TMP_Text text)
    {
        foreach (TextBase entry in collectedTexts)
        {
            if (entry.text == text)
            {
                return true;
            }
        }
        return false;
    }
    // collect all text from scene
    public void RefreshCollectedTextComponents()
    {
        for (int entryIndex = collectedTexts.Count - 1; entryIndex >= 0; entryIndex--)
        {
            if (collectedTexts[entryIndex].text == null)
            {
                collectedTexts.RemoveAt(entryIndex);
            }
        }
        TMP_Text[] allText = FindObjectsByType<TMP_Text>(FindObjectsInactive.Include);
        foreach (TMP_Text text in allText)
        {
            if (IsAlreadyCollected(text) == false)
            {
                collectedTexts.Add(new TextBase(text));
            }
        }
    }
    public void UpdateFont()
    {
        // fontInfo load if you have it saved
        if (fontInfo == null)
        {
            fontInfo = new FontInfo();
        }
        foreach (TextBase entry in collectedTexts)
        {
            TMP_Text text = entry.text;

            //need to ignore text that have the ignore tag
            IgnoreFontSettings ignore = text.GetComponent<IgnoreFontSettings>();
            bool changeSize = true; 
            bool changeColour = true; 
            if (ignore)
            {
                changeSize = ignore.changeSize;
                changeColour = ignore.changeColour;
            }

            if (changeSize)
            {
                text.fontSize = entry.baseSize * fontInfo.scale;
                if (text.enableAutoSizing)
                {
                    text.fontSizeMin = entry.minBaseSize * fontInfo.scale;
                    text.fontSizeMax = entry.maxBaseSize * fontInfo.scale;
                }
            }
            if (changeColour)
            {
                if (fontInfo.useDefaultColour)
                {
                    text.color = entry.baseColour;
                }
                else
                {
                    text.color = new Color(fontInfo.color.r, fontInfo.color.g, fontInfo.color.b, entry.baseColour.a);
                }
            }
        }
    }
    public void UpdateAllText()
    {
        RefreshCollectedTextComponents();
        UpdateFont();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateAllText();
    }
    private void Start()
    {
        UpdateAllText();
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

[Serializable]
public class FontInfo
{
    public Color color = Color.white;
    public float scale = 1f;
    public bool useDefaultColour = true;
}
[Serializable]
public class TextBase
{
    public TMP_Text text;
    public float baseSize;
    public float minBaseSize;
    public float maxBaseSize;
    public Color baseColour;

    public TextBase(TMP_Text textToStore)
    {
        text = textToStore;
        baseSize = textToStore.fontSize;
        minBaseSize = textToStore.fontSizeMin;
        maxBaseSize = textToStore.fontSizeMax;
        baseColour = textToStore.color;

    }

}
