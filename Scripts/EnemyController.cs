using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyController : MonoBehaviour
{
    public Transform target;
    public float speed = 2f;
    private float minDistance = 1f;
    private float range;
    private GameObject Player;

    private void Start()
    {
        Player = gameObject.Find("Player");
    }

    void Update()
    {

        

        range = Vector2.Distance(transform.position, target.position);

        if (range > minDistance)
        {
            Debug.Log(range);

            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}