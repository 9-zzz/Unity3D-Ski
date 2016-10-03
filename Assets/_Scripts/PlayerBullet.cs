using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour
{
    Rigidbody rb;

    // Maybe pass in the bullet target to this.

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        //rb.velocity = PlayerController.S.rb.velocity;
        //rb.velocity = new Vector3(PlayerController.S.rb.velocity.x, , PlayerController.S.rb.velocity.z);
    }

    // Update is called once per frame
    void Update()
    {

    }

}
