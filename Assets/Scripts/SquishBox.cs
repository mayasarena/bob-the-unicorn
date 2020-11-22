using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquishBox : MonoBehaviour
{
    private bool bobHasEntered = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
        {
            bobHasEntered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
        {
            bobHasEntered = false;
        }
    }

    public bool getBobHasEntered()
    {
        return bobHasEntered;
    }
}
