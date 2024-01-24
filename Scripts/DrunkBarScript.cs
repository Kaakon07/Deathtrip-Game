using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrunkBarScript : MonoBehaviour
{
    public Slider drunkSlider;

    [SerializeField] float Promille;
    public GameObject distortionField;
    public Material distortionMaterial;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Promille = 0;
        distortionMaterial = distortionField.GetComponent<MeshRenderer>().material;

    }

    // Update is called once per frame
    void Update()
    {
        if (Promille > 0) 
        {
            Promille -= 0.01f * Time.deltaTime; 
        }
        else
        {
            Promille = 0;
        }
        drunkSlider.value = Promille;

        if (Promille <= 0) 
        {
            distortionField.SetActive(false);
        }
        else if (Promille < 0.2)
        {
            distortionField.SetActive(true);
            distortionMaterial.SetVector("_DistortionSpeed",  new Vector4(0.05f, 0f, 0f,0f));
            distortionMaterial.SetVector("_DistortionPower", new Vector4(0.05f, 0f, 0f, 0f));
        }  

    }
}
