using UnityEngine;
using System.Collections;

public class AudioSkybox : MonoBehaviour
{

    AudioSpectrum spectrum;

    public int[] ind;

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
        Camera.main.GetComponent<Camera>().backgroundColor = new Color(
       (0.05f / spectrum.MeanLevels[ind[0]]),
       (0.05f / spectrum.MeanLevels[ind[1]]),
       (0.05f / spectrum.MeanLevels[ind[2]]));
    }

}
