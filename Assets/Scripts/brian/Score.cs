using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public enum Mode
    {
        WaveCrabs,
        WaveHome,
        OneShot
    }

    public Mode _mode;

    public TextMeshProUGUI _topTimed, _topShots;

    public void OnEnable()
    {
        if(_mode == Mode.WaveCrabs)
        {
            _topTimed.text = PlayerPrefs.GetString("Time");
            _topShots.text = PlayerPrefs.GetString("Shots");
        }

        else if (_mode == Mode.WaveHome)
        {
            _topTimed.text = PlayerPrefs.GetString("Time_spons");
            _topShots.text = PlayerPrefs.GetString("Shots_spons");
        }

        else if (_mode == Mode.OneShot)
        {
            _topTimed.text = PlayerPrefs.GetString("Time_OneShot");
        }
    }
}
