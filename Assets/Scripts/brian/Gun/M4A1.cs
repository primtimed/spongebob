using TMPro;
using UnityEngine;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class M4A1 : BaseGun
{
    public override void Shoot()
    {
        if (shootDelay < extra.timer && ammoCount > 0 && extra.reload == false)
        {

            base.Shoot();

            ammoCount -= 1;
            base.extra.ammoText.text = ammoCount.ToString() + "/" + extra.startAmmo;

            if (ammoCount == 0)
            {
                extra.ammoText.color = Color.red;
                //extra.reloadText.GetComponent<TextMeshProUGUI>().enabled = true;
            }

            base.extra.ammoText.text = ammoCount.ToString() + "/" + extra.startAmmo;
        }
    }

    public override void Reload()
    {
        base.Reload();
    }
}
