using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerInfoText : MonoBehaviour
{
    PlayerController player;

    float vel;
    string height;

    Text tex;

    public LayerMask environmentMask;

    // Use this for initialization
    void Start()
    {
        player = PlayerController.S;

        tex = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        vel = player.rb.velocity.magnitude;

        tex.text = "VELOCITY: " + vel + "\nHEIGHT: " + height;

        RaycastHit _hit;

        if (Physics.Raycast(player.transform.position, Vector3.down, out _hit, 100f, environmentMask))
        {
            height = Vector3.Distance(player.transform.position, _hit.point).ToString();
        }
        else
        {
            height = "NULL";
        }
    }

}
