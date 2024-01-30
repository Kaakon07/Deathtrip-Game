using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{ 
    // destorys an object after a certain amount of time
    public float amount = 2;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, amount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
