using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    private Animator anim;
    private bool spikesDone = false;
    public GameObject damageZone;
    public Transform target;

    void Start()
    {
        anim = GetComponent<Animator>();
        damageZone.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player" && !spikesDone) { 
            StartCoroutine(TriggerSpikes());
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player") { 
            spikesDone = false;
        }
    }

    IEnumerator TriggerSpikes()
    {
        damageZone.SetActive(true); 
        anim.Play("Spikes");
        yield return new WaitForSeconds(1.58f);
        spikesDone = true;
        damageZone.SetActive(false);
    }
}
