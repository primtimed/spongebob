using System.Collections;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class JellyAi : MonoBehaviour
{
    public GameObject _weapon;
    public Vector2 _shootDelay;

    GameObject _target;

    private void Start()
    {
        _target = GameObject.Find("Player");
        StartCoroutine(shoot());
    }
    
    private void Update()
    {
        transform.LookAt(_target.transform.position);
    }

    public IEnumerator shoot()
    {
        Instantiate(_weapon, transform.position, transform.rotation);
        yield return new WaitForSeconds(Random.Range(_shootDelay.x, _shootDelay.y));
        StartCoroutine(shoot());
    }
}
