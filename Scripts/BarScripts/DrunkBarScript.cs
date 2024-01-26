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
    public float totalPromille;
    public Vector4 distortionSpeed;
    public GameObject distortionField;
    public Material distortionMaterial;
    public ValueScript valuescript;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Promille = 0;
        totalPromille = 0;
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
            distortionField.SetActive(false);
        }
        else if (Promille > 0)
        {
            distortionSpeed = new Vector4(Mathf.Pow(Mathf.Pow(2, Promille) - 1, 2), Mathf.Pow(2 * Promille, 4) * 0.015625f, 0f, 0f)*0.0078125f;
            distortionMaterial.SetVector("DistortionSpeed", distortionSpeed);
            distortionMaterial.SetVector("DistortionPosition", distortionMaterial.GetVector("DistortionPosition") + distortionSpeed);
            distortionMaterial.SetVector("DistortionPower", new Vector4( (Mathf.Pow(2, Promille) - 1) * Promille, Mathf.Pow(2 * Promille, 4) / 64, 0f, 0f) );
            distortionField.SetActive(true);
            Debug.Log(distortionMaterial.GetVector("DistortionPosition").ToString());
            Debug.Log(distortionSpeed);
        }
        else
        {
            distortionField.SetActive(false);
        }  

    }
}
