using UnityEngine;
using System.Collections;

public class SurfBall : MonoBehaviour
{
    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(rb.velocity.x, -10, rb.velocity.z);

        RaycastHit _hit;

        if (Physics.Raycast(transform.position, Vector3.down, out _hit, 1.65f))
        {
            //transform.position = new Vector3(transform.position.x, _hit.point.y+2, transform.position.z);

            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        }
    }

    void OnMouseDown()
    {
        rb.AddForce(GameObject.Find("Player").transform.position - transform.position, ForceMode.Impulse);
    }

}
