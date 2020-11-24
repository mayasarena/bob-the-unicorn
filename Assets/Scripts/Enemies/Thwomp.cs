using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thwomp : MonoBehaviour
{
    public float speedDown = 30f; // Speed of thwomp coming down
    public float speedUp = 15f; //Speed of thwomp on way up
    public float waitTimeTop = 10f; // Delay once top is reached
    public float waitTimeBottom = 3f; // Delay once bottom is reached
    
    private Vector3 startPoint; 
    public Transform target;

    // Squish 
    public GameObject bob;
    public SquishBox squishBox;
    public float squishTime = 5f;
    public int damageToGive = 10;
    public float squishRadius = 0.3f;
    private float originalRadius;

    // Bools
    private bool damaged = false; // Check if player has been damaged
    private bool goUp = false; // Check if thwomp is going up
    private bool waited = false; // Check if thwomp has waited

    private AudioSource thwompAudio;

    void Start()
    {
        thwompAudio = GetComponent<AudioSource>();
        startPoint = transform.position; // Saving start point
        originalRadius = bob.GetComponent<CircleCollider2D>().radius; // Saving Bob's collider radius (for when he gets squished)
        StartCoroutine(ThwompMovement()); 
    }

    IEnumerator ThwompMovement()
    {
        while (!goUp) // While thwomp is going down
        {
            if (!waited) // Check if thwomp has waited the delay
            {
                yield return new WaitForSeconds(waitTimeTop); // Delay launch
                waited = true;
            }
            transform.position = Vector3.MoveTowards(transform.position, target.position, speedDown * Time.deltaTime); // Move towards target 
            yield return null;
        }
    
        while (goUp) // While thwomp is going up
        {
            damaged = false; // Player has not been damaged

            if (!waited) // Check if thwomp has waited delay
            {
                yield return new WaitForSeconds(waitTimeBottom); // Delay launch
                waited = true;
            }
            transform.position = Vector3.MoveTowards(transform.position, startPoint, speedUp * Time.deltaTime); // Move towards top       

            if (Vector3.Distance(transform.position, startPoint) < 0.001f) // Check if top has been reached
            {
                goUp = false;
                waited = false;
                StartCoroutine(ThwompMovement()); // Go through coroutine again
            }
            yield return null;
        }    
    }

    private void OnCollisionEnter2D(Collision2D other) 
    { 
        if (other.gameObject.tag == "Ground" && !goUp) // If the thwomp reaches the ground 
        { 
            thwompAudio.Play();
            goUp = true;
            waited = false;
            StartCoroutine(ThwompMovement());
        }
    }   

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Squish" && !goUp && squishBox.getBobHasEntered()) // Check if Bob should be squished
        {
            thwompAudio.Play();
            StartCoroutine(SquishBob());
        }
    }

    IEnumerator SquishBob()
    {
        bob.transform.localScale = new Vector3(1f, 0.2f, 1f); // Change Bob's scale so he appears squished
        bob.GetComponent<CircleCollider2D>().radius = squishRadius; // Edit collider size with his scale
        bob.GetComponent<PlayerController>().enabled = false; // Disable player controller

        if (!damaged) // Make sure Bob only gets damaged once per squish
        {
            FindObjectOfType<HealthManager>().HurtPlayer(damageToGive, false, gameObject.transform);
            damaged = true;
        }
        // Lock Bob until squish time is up then return him back to normal
        yield return new WaitForSeconds(squishTime); 
        bob.transform.localScale = new Vector3(1f, 1f, 1f);
        bob.GetComponent<CircleCollider2D>().radius = originalRadius;
        bob.GetComponent<PlayerController>().enabled = true;
        
    }

}
