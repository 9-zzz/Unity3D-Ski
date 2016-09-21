using UnityEngine;
using System.Collections;

public class SwordController : MonoBehaviour
{
    Animator anim;
    public float comboTimer = 100.0f;

    public bool firstSlash = false;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            anim.SetBool("slashing", true);

            firstSlash = true;
        }

        if(firstSlash)
        {
            comboTimer -= 0.05f;
        }

        if(Input.GetMouseButtonDown(0) && firstSlash && comboTimer > 0)
        {
            anim.SetBool("slashing2", true);
        }

        if(Input.GetMouseButtonUp(0))
        {
            //firstSlash = false;

            anim.SetBool("slashing", false);
            anim.SetBool("slashing2", false);
            //comboTimer = 100.0f;
        }
    }

}
