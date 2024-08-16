using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JB_RayCast : MonoBehaviour
{
    public float radius = 5f; // Radius of the circle
    public LayerMask layerMask; // Layers to include in the overlap check

    void Update()
    {
        // Get all colliders within the circle
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radius, layerMask);

        foreach (var collider in hitColliders)
        {
            Debug.Log("Detected: " + collider.name);
        }
    }

}
