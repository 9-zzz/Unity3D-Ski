using UnityEngine;
using System.Collections;

public class PlayerGun : MonoBehaviour
{
    public float speed = 10;
    public float bulletLifetime = 5.0f;

    public GameObject playerBullet;

    [SerializeField]
    private LayerMask environmentMask;

    Transform sp;

    // Use this for initialization
    void Start()
    {
        sp = transform.GetChild(0).transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit _hit;
            Vector3 dir;

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out _hit, 4000f, environmentMask))
            {
                dir = (_hit.point - sp.position).normalized;

                //GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                //sphere.transform.position = _hit.point;

                Debug.Log("hit a thing");
            }
            else
            {
                dir = Camera.main.transform.forward; // The ray?
                Debug.Log("hit nothing");
            }

            var rot = Quaternion.FromToRotation(playerBullet.transform.forward, dir);

            var _playerBullet = Instantiate(playerBullet, sp.transform.position, rot) as GameObject;

            //_playerBullet.GetComponent<Rigidbody>().velocity = new Vector3(PlayerController.S.rb.velocity.x, , PlayerController.S.rb.velocity.z);

            //_playerBullet.GetComponent<Rigidbody>().velocity += (dir * speed);
            _playerBullet.GetComponent<Rigidbody>().AddForce((dir * speed), ForceMode.Impulse);

            Destroy(_playerBullet.gameObject, bulletLifetime);
        }
    }

}
