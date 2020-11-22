using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform start, end;
    private bool moveForward = true;
    public float speed = 10f;
    public GameObject platform;

    void Start()
    {
        platform.transform.position = start.transform.position;
    }

    void Update()
    {
        if (moveForward) { // Move the platform to end
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, end.position, Time.deltaTime * speed);

            if (platform.transform.position == end.transform.position) {
                moveForward = false;
            }
        }

        if (!moveForward) { // Move the platform back to start
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, start.position, Time.deltaTime * speed);

            if (platform.transform.position == start.transform.position) {
                moveForward = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) // Make player stick to platform
    { 
        if (other.gameObject.tag == "Player") 
        { 
            other.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other) // De-stick player from platform when they leave
    { 
        if (other.gameObject.tag == "Player") 
        { 
            other.transform.parent = null;
        }
    }
}
