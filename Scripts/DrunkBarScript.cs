using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrunkBarScript : MonoBehaviour
{
    public Slider drunkSlider;

    [SerializeField] float Promille;
    public GameObject distortionField;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Promille = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Promille >= 0) 
        {
            Promille -= 0.01f * Time.deltaTime; 
        }
        drunkSlider.value = Promille;
    }
}
