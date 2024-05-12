using UnityEngine;
using System.Collections;
using TMPro;

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

    private void Start()
    {
        currentAmmo = maxAmmo;
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
