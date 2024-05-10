using UnityEngine;

public class GunScript : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    float shootTimer = 0.1f;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0)
            {
                Shoot();
                shootTimer = 0.1f;
            }

        }
    }

    void Shoot()
    {
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
