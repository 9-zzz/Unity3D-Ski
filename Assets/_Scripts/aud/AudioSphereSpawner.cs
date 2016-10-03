using UnityEngine;
using System.Collections;

public class AudioSphereSpawner : MonoBehaviour
{
    public GameObject audioDiamond;
    public GameObject audioSphere;
    public GameObject audioObj;

    public float range;
    public int count;
    public int skyCount;
    public GameObject skyPoint;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < skyCount; i++)
        {
            var rv = Random.insideUnitCircle;
            var rh = new Vector3(rv.x, 0f, rv.y);

            var asp = Instantiate(audioSphere, skyPoint.transform.position + rh * 500, transform.rotation) as GameObject;

            var randScale = Random.Range(5, 20);

            asp.transform.localScale = new Vector3(randScale, randScale, randScale);
        }

        for (int i = 0; i < count; i++)
        {
            var aobj = Instantiate(audioObj,
                            (transform.position + Random.insideUnitSphere * range) - (transform.position + Random.insideUnitSphere * range * 2),
                            transform.rotation) as GameObject;



            for (int j = 2; j < 8; j++)
            {

                var ad = Instantiate(audioDiamond, transform.position + Random.insideUnitSphere * range, transform.rotation) as GameObject;

                ad.GetComponent<AudioDiamond>().hvar = 2;

                ad.transform.parent = transform;
            }

            aobj.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //transform.eulerAngles = new Vector3(0, (transform.GetChild(0).GetComponent<AudioSphere>().rotater*10) * Time.deltaTime, 0);
    }

}
