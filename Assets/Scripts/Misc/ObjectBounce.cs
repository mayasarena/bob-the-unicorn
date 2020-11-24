using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBounce : MonoBehaviour
{
    public float bounceAmount = 1f;
    private float initialPosy;

    void Start()
    {
        initialPosy = transform.position.y;
    }

    void Update()
    {
        // Make items bounce up and down in the air
        transform.position = new Vector3(transform.position.x, initialPosy + ((float)Mathf.Sin(Time.time) * bounceAmount), transform.position.z);
    }
}
