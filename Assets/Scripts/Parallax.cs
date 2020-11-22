using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private Transform cam;
    private Vector3 lastCamPos;
    public Vector2 parallaxMultiplier;
    
    private void Start()
    {
        cam = Camera.main.transform;
        lastCamPos = cam.position;
    }

    private void LateUpdate()
    {
        Vector3 camMovement = cam.position - lastCamPos;
        transform.position += new Vector3(camMovement.x * parallaxMultiplier.x, camMovement.y * parallaxMultiplier.y);
        lastCamPos = cam.position;
    }

}
