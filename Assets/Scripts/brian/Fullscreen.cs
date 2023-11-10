using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fullscreen : MonoBehaviour
{
    Toggle _fullscreen;

    private void OnEnable()
    {
        _fullscreen = GetComponent<Toggle>();

        if (Screen.fullScreen)
        {
            _fullscreen.isOn = true;
        }

        else
        {
            _fullscreen.isOn = false;
        }
    }
}
