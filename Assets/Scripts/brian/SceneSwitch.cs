using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void Scene(int _index)
    {
        SceneManager.LoadScene(_index);
    }
}