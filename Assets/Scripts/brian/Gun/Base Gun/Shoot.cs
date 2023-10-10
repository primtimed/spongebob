using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    private Movement Player;

    private bool isShooting;

    public FireMode fireMode;

    private PlayerControlls input;

    public enum FireMode
    {
        single,
        auto
    }

    public void Awake()
    {
        input = new PlayerControlls();
    }

    private void OnEnable()
    {
        input.Enable();
        
        input.DeafultMovement.Shoot.started += ShootV;
        input.DeafultMovement.Shoot.canceled += ShootV;
        input.DeafultMovement.Reload.started += Reload;
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Movement>();
    }

    private void Update()
    {
        if (isShooting == true)
        {
            GetComponent<BaseGun>().Shoot();
        }
    }
    public void ShootV(InputAction.CallbackContext context)
    {
        if (context.started && (fireMode == FireMode.single || fireMode == FireMode.auto))
        {
            GetComponent<BaseGun>().Shoot();

            if (fireMode == FireMode.auto)
            {
                isShooting = true;
            }
        }

        if (context.canceled && fireMode == FireMode.auto)
        {
            isShooting = false;
        }
    }

    public void Reload(InputAction.CallbackContext context)
    {
        print("reload");
        GetComponent<BaseGun>().Reload();
    }
}
