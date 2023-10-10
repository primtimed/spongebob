using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BaseGun : MonoBehaviour
{
    public class Extra
    {
        public GameObject hitmarker, cam, reloadText;

        public Vector3 bloom;

        public int startAmmo;

        public TextMeshProUGUI ammoText, aim;

        public float timer;

        public bool reload;

        public AudioSource reloadSound;
    }

    public int ammoCount, maxDistance, damage, reloadTime;
    public float bloomRange, shootDelay;

    public Extra extra;

    private AudioSource shoot;
    public GameObject flash;
    private WeaponShake shake;
    public GameObject hitO;

    public GameObject _ParticalLoc;
    public GameObject _ShootTrail;

    private Timer _timer;
    private void Awake()
    {
        extra = new Extra();

        extra.startAmmo = ammoCount;

        _timer = GameObject.Find("Keep").GetComponent<Timer>();
        extra.ammoText = GameObject.Find("Ammo").GetComponent<TextMeshProUGUI>();
        extra.ammoText.text = ammoCount.ToString() + "/" + extra.startAmmo;

        extra.cam = GameObject.Find("Camera");

        extra.startAmmo = ammoCount;
    }

    private void Update()
    {
        extra.timer += Time.deltaTime;
    }

    public virtual void Shoot()
    {
        print("Shoot");

        extra.timer = 0;

        _timer._shots += 1;
        
        GameObject _flash = Instantiate(flash, GameObject.Find("Flash").transform.position, Quaternion.identity);
        _flash.transform.parent = _ParticalLoc.transform;



        if (transform.GetComponent<Shotgun>().enabled)
        {
            extra.bloom = extra.cam.transform.position + extra.cam.transform.forward * 100;
            extra.bloom += Random.Range(-bloomRange, bloomRange) * extra.cam.transform.up;
            extra.bloom += Random.Range(-bloomRange, bloomRange) * extra.cam.transform.right;
            extra.bloom -= extra.cam.transform.position;
            extra.bloom.Normalize();
        }
        else
        {
            extra.bloom = extra.cam.transform.forward;
        }

        RaycastHit hit;
        if(Physics.Raycast(extra.cam.transform.position, extra.bloom, out hit, maxDistance))
        {
            GameObject _hit = Instantiate(hitO, hit.point, hit.transform.rotation);
            _hit.transform.parent = _ParticalLoc.transform;

            if (hit.transform.tag == "Enemy")
            {
                hit.transform.GetComponent<AI>()._health -= damage;
                Hit();
            }

            if (hit.transform.tag == "Boss")
            {
                hit.transform.GetComponent<AIBoss>()._health -= damage;
                Hit();
            }
        }
    }

    public async void Hit()
    {
        //extra.hitmarker.GetComponent<RawImage>().enabled = true;

        await Task.Delay(100);

        //extra.hitmarker.GetComponent<RawImage>().enabled = false;
    }

    public virtual async void Reload()
    {
        //extra.reloadSound.Play();

        extra.reload = true;
        await Task.Delay((int) reloadTime);

        ammoCount = extra.startAmmo;
        extra.ammoText.text = ammoCount.ToString() + "/" + extra.startAmmo.ToString();

        extra.ammoText.color = new Color (255, 255, 255);
        extra.reload = false;

        //extra.reloadText.GetComponent<TextMeshProUGUI>().enabled = false;
    }
}
