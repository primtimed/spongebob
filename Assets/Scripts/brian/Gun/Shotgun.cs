using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shotgun : BaseGun
{
    public override void Shoot()
    {
        if (shootDelay < extra.timer && ammoCount > 0 && extra.reload == false)
        {
            base.Shoot();
            base.Shoot();
            base.Shoot();
            base.Shoot();
            base.Shoot();

            ammoCount -= 1;
            base.extra.ammoText.text = ammoCount.ToString() + "/" + extra.startAmmo;


            if (ammoCount == 0)
            {
                extra.ammoText.color = Color.red;
            }

            base.extra.ammoText.text = ammoCount.ToString() + "/" + extra.startAmmo;
        }
    }
    public override void Reload()
    {
        base.Reload();
    }
}
