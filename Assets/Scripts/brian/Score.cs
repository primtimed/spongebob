using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI _topTimed, _topShots;

    private void Start()
    {
        _topTimed.text = PlayerPrefs.GetString("Time");
        _topShots.text = PlayerPrefs.GetInt("Shots").ToString();
    }
}
