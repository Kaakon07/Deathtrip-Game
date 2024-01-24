using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    // makes an object follow a target, wiht optional offset
    public GameObject target;
    private Transform TargetTransform;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        TargetTransform = target.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = TargetTransform.position - offset;
    }
}
