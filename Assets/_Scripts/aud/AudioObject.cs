using UnityEngine;

public class AudioObject : MonoBehaviour
{
    AudioSpectrum spectrum;

    public bool randomize = false;

    public float rotater;

    public int[] ind;

    public bool scale = false;
    public bool color = false;

    void Awake()
    {
        spectrum = FindObjectOfType(typeof(AudioSpectrum)) as AudioSpectrum;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //rotater = Mathf.MoveTowards(rotater, spectrum.Levels[3] * 3, Time.deltaTime * 20);

        if (scale)
            transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(transform.localScale.x, 14.13f * spectrum.PeakLevels[2], transform.localScale.z), Time.deltaTime * 30);

        this.GetComponent<Renderer>().material.color = new Color(
            (0.05f / spectrum.MeanLevels[ind[0]]),
            (0.05f / spectrum.MeanLevels[ind[1]]),
            (0.05f / spectrum.MeanLevels[ind[2]]));
    }

}
