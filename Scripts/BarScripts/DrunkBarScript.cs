using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrunkBarScript : MonoBehaviour
{
    //referanser
    public Slider drunkSlider;
    // promille level
    public float Promille;
    public GameObject distortionField;
    public Material distortionMaterial;
    public ValueScript valuescript;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Promille = 0;
        distortionMaterial = distortionField.GetComponent<SpriteRenderer>().material;

    }

    // Update is called once per frame
    void Update()
    {
        if (Promille > 0) 
        {
            Promille -= 0.01f * Time.deltaTime; 
            distortionField.SetActive(true);
        }
        else
        {
            Promille = 0;
        }
        drunkSlider.value = Promille;

        // skifter på skjermen baser på hvor full du er
        if (Promille >= 1)
        {
            valuescript.currentHealth = -999;
        }
        else if (Promille >= 0.9) 
        {
            distortionMaterial.SetVector("DistortionSpeed", new Vector4(0.75f, 0.15f, 0f, 0f));
            distortionMaterial.SetVector("DistortionPower", new Vector4(0.75f, 0.15f, 0f, 0f));

        }
        else if (Promille >= 0.8)
        {
            distortionMaterial.SetVector("DistortionSpeed", new Vector4(0.25f, 0.10f, 0f, 0f));
            distortionMaterial.SetVector("DistortionPower", new Vector4(0.40f, 0.10f, 0f, 0f));

        }
        else if (Promille >= 0.5)
        {
            distortionMaterial.SetVector("DistortionSpeed", new Vector4(0.10f, 0.01f, 0f, 0f));
            distortionMaterial.SetVector("DistortionPower", new Vector4(0.20f, 0.01f, 0f, 0f));

        }
        else if (Promille >= 0.2)
        {
            distortionMaterial.SetVector("DistortionSpeed", new Vector4(0.05f, 0f, 0f, 0f));
            distortionMaterial.SetVector("DistortionPower", new Vector4(0.10f, 0f, 0f, 0f));

        }
        else if (Promille > 0)
        {
            distortionField.SetActive(true);
        }
        else
        {
            distortionField.SetActive(false);
        }  

    }
}
