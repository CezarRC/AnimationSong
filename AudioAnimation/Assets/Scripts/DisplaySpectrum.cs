using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaySpectrum : MonoBehaviour
{
    public GameObject instantiationPrefab;
    GameObject[] instances = new GameObject[512];
    float prefabScale = 100000;
    public SpectrumReader spectrumReader;
    float[] spectrum = new float[512];

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 512; i++)
        {
            GameObject prefabInstance = (GameObject)Instantiate(instantiationPrefab);
            prefabInstance.transform.position = this.transform.position;
            prefabInstance.transform.parent = this.transform;
            prefabInstance.name = "PrefabSample" + i;
            this.transform.eulerAngles = new Vector3(0, -0.703125f * i, 0);
            prefabInstance.transform.position = Vector3.forward * 100;
            instances[i] = prefabInstance;
        }

    }

    // Update is called once per frame
    void Update()
    {
        spectrum = spectrumReader.GetSpectrum();
        for (int i = 0; i < 512; i++)
        {
            if (instances != null)
            {
                instances[i].transform.localScale = new Vector3(10, (spectrum[i] * prefabScale) + 2, 10);
            }
        }
    }
}
