using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;



public class GrabDetection : MonoBehaviour
{
    public bool isGrabbed;
    public bool insideSnapZone;
    [SerializeField] Rigidbody rb;
    
    void Update()
    {
        if (rb.isKinematic && insideSnapZone == false)
        {
            Debug.Log("grabbed");
            isGrabbed = true;
        }

        if (!rb.isKinematic)
        {
            isGrabbed = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            rb.isKinematic = false;
            insideSnapZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        rb.isKinematic = true;
        insideSnapZone = false;
    }
}


