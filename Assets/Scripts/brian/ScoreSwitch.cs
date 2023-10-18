using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSwitch : MonoBehaviour
{
    public TMP_Dropdown _dropDown;

    public GameObject[] _ui;

    private void Start()
    {
        _dropDown = GetComponent<TMP_Dropdown>();
    }

    private void Update()
    {
        if(_dropDown.value == 0)
        {
            _ui[0].SetActive(true);
            _ui[1].SetActive(false);
            _ui[2].SetActive(false);
        }

        else if(_dropDown.value == 1)
        {
            _ui[0].SetActive(false);
            _ui[1].SetActive(true);
            _ui[2].SetActive(false);
        }

        else if(_dropDown.value == 2)
        {
            _ui[0].SetActive(false);
            _ui[1].SetActive(false);
            _ui[2].SetActive(true);
        }
    }
}
