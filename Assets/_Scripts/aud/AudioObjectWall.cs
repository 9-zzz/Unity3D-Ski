using UnityEngine;

public class AudioObjectWall : MonoBehaviour
{
    AudioSpectrum spectrum;

    //public bool randomize = false;

    //public float rotater;

    public int[] ind;

    void Awake()
    {
        spectrum = FindObjectOfType(typeof(AudioSpectrum)) as AudioSpectrum;
    }


    void Start()
    {

    }

    void Update()
    {
        //transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(transform.localScale.x, 14.13f * spectrum.PeakLevels[2], transform.localScale.z), Time.deltaTime * 30);

        this.GetComponent<Renderer>().material.color = new Color(
            (0.05f / spectrum.MeanLevels[ind[0]]),
            (0.05f / spectrum.MeanLevels[ind[1]]),
            (0.05f / spectrum.MeanLevels[ind[2]]));
    }

}
