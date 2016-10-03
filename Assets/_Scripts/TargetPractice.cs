using UnityEngine;
using System.Collections;

public class TargetPractice : MonoBehaviour
{
    public AudioClip[] dingSounds;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "playerBullet")
        {
            AudioSource.PlayClipAtPoint(dingSounds[Random.Range(0, 4)], transform.position);
        }
    }

}
