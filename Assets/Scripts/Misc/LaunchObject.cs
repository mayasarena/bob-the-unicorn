using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchObject : MonoBehaviour
{
    public float startRange = 5f, endRange = 15f;
    private float waitTime;
    public GameObject obj;
    public Transform firePoint;
    public AudioSource launchAudio;

    void Start()
    {
        StartCoroutine(LaunchObjectCo());
    }
    
    IEnumerator LaunchObjectCo()
    {
        while (true)
        {
            launchAudio.Play();
            Instantiate(obj, firePoint.position, firePoint.rotation);
            waitTime = Random.Range(startRange, endRange); // Get a random time to re-launch
            yield return new WaitForSeconds(waitTime); // Delay launch
        }
    }
}
