using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayUsableSpectrum : MonoBehaviour
{
    public SpectrumReader reader;
    public Material mat;
    public Light light;
    public ParticleSystem parts;
    public int frequence;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        float[] usableSpectrum = reader.GetUsableSpectrum();
        Debug.Log(usableSpectrum[frequence]);
        transform.localScale = new Vector3(transform.localScale.x, (usableSpectrum[frequence] * 10) + 1, transform.localScale.z);
        mat.SetColor("_EmissionColor", new Color(usableSpectrum[frequence] * 10 + 10, 0, 0));
        light.intensity = usableSpectrum[frequence] * 25;
        parts.emissionRate = usableSpectrum[2] * 0.5f;
        parts.gravityModifier = usableSpectrum[0] * -0.1f;
    }
}
