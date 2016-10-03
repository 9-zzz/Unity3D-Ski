using UnityEngine;

public class AudioDiamond : MonoBehaviour
{
    AudioSpectrum spectrum;

    public bool randomize = false;

    public float rotater;
    public int hvar;

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

        rotater = Mathf.MoveTowards(rotater, spectrum.Levels[3]*3, Time.deltaTime * 20);

        if (randomize == false)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(transform.localScale.x, 14.13f * spectrum.Levels[hvar], transform.localScale.z), Time.deltaTime * 30);

            this.GetComponent<Renderer>().material.color = new Color(
                (0.05f / spectrum.MeanLevels[5]),
                (0.05f / spectrum.MeanLevels[7]),
                (0.05f / spectrum.MeanLevels[0]));
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, 10.13f * spectrum.Levels[Random.Range(0, 10)], transform.localScale.z);

            this.GetComponent<Renderer>().material.color = new Color(
                (0.05f / spectrum.MeanLevels[Random.Range(0, 10)]),
                (0.05f / spectrum.MeanLevels[Random.Range(0, 10)]),
                (0.05f / spectrum.MeanLevels[Random.Range(0, 10)]));
        }

    }

}
