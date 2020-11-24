using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    private Animator anim;
    private bool spikesDone = false;
    public GameObject damageZone; // Where damage is given
    public Transform target;

    void Start()
    {
        anim = GetComponent<Animator>();
        damageZone.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player" && !spikesDone) { 
            StartCoroutine(TriggerSpikes()); // Trigger spikes when player comes near
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player") { 
            spikesDone = false; // Once player leaves, the spikes go down
        }
    }

    IEnumerator TriggerSpikes()
    {
        damageZone.SetActive(true); // Spikes can now injure player
        anim.Play("Spikes"); // Animation
        yield return new WaitForSeconds(1.58f);
        spikesDone = true;
        damageZone.SetActive(false); // Spikes go back down until player leaves and comes back
    }
}
