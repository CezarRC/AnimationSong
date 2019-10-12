using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class SpectrumReader : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField]
    float[] samples = new float[512];
    float[] usableSpectrum = new float[8];
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSpectrum();
        UpdateUsableSpectrum();
    }

    void UpdateSpectrum()
    {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    void UpdateUsableSpectrum()
    {
        int count = 0;

        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            if (i == 7)
            {
                sampleCount += 2;
            }
            for (int j = 0; j < sampleCount; j++)
            {
                average += samples[count] * (count + 1);
                count++;
            }
            average /= count;
            usableSpectrum[i] = average * 10;
        }
    }

    public float[] GetSpectrum()
    {
        return samples;
    }

    public float[] GetUsableSpectrum()
    {
        return usableSpectrum;
    }
}
