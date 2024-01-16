using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    public Camera mainCam;
    private Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = mainCam.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        
    }
}
