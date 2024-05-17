using UnityEngine;
using System.Collections;
using TMPro;
using JetBrains.Annotations;

public class GunScript : MonoBehaviour
{
    public TextMeshProUGUI ammoText;
    string currentAmmoText;
    string maxAmmoText;

    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    float shootTimer = 0.1f;

    public int maxAmmo = 30;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;
    public Animator anim;

    AudioSource shootingSound;
    public GameObject shootingSoundObj;
    public AudioClip shootingClip;

    AudioSource reloadingSound;
    public GameObject reloadingSoundObj;
    public AudioClip reloadingClip;

    private void Start()
    {
        currentAmmo = maxAmmo;
        shootingSound = shootingSoundObj.GetComponent<AudioSource>();
        reloadingSound = reloadingSoundObj.GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        isReloading = false;
        anim.SetBool("Reloading", false);
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text = currentAmmoText + "/" + maxAmmoText;
        currentAmmoText = currentAmmo.ToString();
        maxAmmoText = maxAmmo.ToString();
        if (isReloading)
            return;

        if(currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if(Input.GetButton("Fire1"))
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0)
            {
                Shoot();
                shootTimer = 0.1f;
            }
        }

        if(Input.GetKeyDown(KeyCode.R) && currentAmmo != maxAmmo)
        {
            StartCoroutine (Reload());
        }
    }

    IEnumerator Reload()
    {
        reloadingSound.PlayOneShot(reloadingClip);
        isReloading = true;
        Debug.Log("Reloading");
        anim.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime - .25f);
        anim.SetBool("Reloading", false);
        yield return new WaitForSeconds(reloadTime - .25f);

        currentAmmo = maxAmmo;
        isReloading = false;
    }

    void Shoot()
    {
        currentAmmo--;

        muzzleFlash.Play();
        shootingSound.PlayOneShot(shootingClip);
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            ZombieHealth zombie = hit.transform.GetComponent<ZombieHealth>();
            if(zombie != null)
            {
                zombie.TakeDamage(damage);
            }
        }

    }
}
