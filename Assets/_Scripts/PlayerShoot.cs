using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    private const string PLAYER_TAG = "Player";

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private LayerMask mask;

    void Start()
    {
        if (cam == null)
        {
            Debug.LogError("PlayerShoot: No camera referenced!");
            this.enabled = false;
        }
    }

    void Update()
    {
        //if (PauseMenu.IsOn) return;

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                //InvokeRepeating("Shoot", 0f, 1f / currentWeapon.fireRate);
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                CancelInvoke("Shoot");
            }
        }
    }

    void Shoot()
    {
        RaycastHit _hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, 100.0f, mask))
        {
            if (_hit.collider.tag == PLAYER_TAG)
            {
                //CmdPlayerShot(_hit.collider.name, currentWeapon.damage, transform.name);
            }

            // We hit something, call the OnHit method on the server
            //CmdOnHit(_hit.point, _hit.normal);
        }

    }

}
