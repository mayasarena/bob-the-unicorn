using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform start, end; // The start and end locations
    private bool moveForward = true; 
    public float speed = 10f; // The speed of the movement

    void Start()
    {
        transform.position = start.transform.position;
    }

    void Update()
    {
        // Move enemy back and forth
        if (moveForward) { 
            transform.position = Vector3.MoveTowards(transform.position, end.position, Time.deltaTime * speed);

            if (transform.position == end.transform.position) {
                moveForward = false;
            }
        }

        if (!moveForward) { 
            transform.position = Vector3.MoveTowards(transform.position, start.position, Time.deltaTime * speed);

            if (transform.position == start.transform.position) {
                moveForward = true;
            }
        }
    }
}
