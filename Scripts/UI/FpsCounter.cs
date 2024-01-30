using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FpsCounter : MonoBehaviour
{
    public Text counter;

    private void FixedUpdate()
    {
        counter.text = ( (int)(Time.frameCount / Time.time) ).ToString();

    }
}
