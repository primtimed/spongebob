using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public GameObject _loading;
    public void Scene(int _index)
    {
        StartCoroutine(test(_index));
    }

    IEnumerator test(int _index)
    {
        _loading.SetActive(true);
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene(_index);
    }
}