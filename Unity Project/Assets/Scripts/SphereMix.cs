using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMix : MonoBehaviour
{
    
     SphereLauncher sphereLauncher;

    private void Start()
    {
        sphereLauncher = FindObjectOfType<SphereLauncher>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody currentSphere = other.attachedRigidbody;
        if (currentSphere != null)
        {
            Renderer sphereRenderer = currentSphere.GetComponent<Renderer>();
            if (sphereRenderer != null)
            {
                Color sphereColor = sphereRenderer.material.color;
//                ColorPlaneAtPosition(other.transform.position, currentSphere.transform.localScale.x / 2f, sphereColor);
            }
        }
    }
}
