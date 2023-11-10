using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public string[] _loadingText;
    public Texture[] _loadingImages;

    private TextMeshProUGUI _textMeshProUGUI;
    private RawImage _image;

    private void OnEnable()
    {
        _image = GetComponentInChildren<RawImage>();
        _textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();

        int _text = Random.Range(0, _loadingText.Length);
        int _screen = Random.Range(0, _loadingImages.Length);

        _image.texture = _loadingImages[_screen];
        _textMeshProUGUI.text = _loadingText[_text];
    }
}
