using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SnapObject : MonoBehaviour
{
    public GameObject SnapLocation;

    public GameObject kiinnike;

    public bool isSnapped;

    private bool objectSnapped;

    private bool grabbed;


    // Update is called once per frame
    void Update()
    {
        grabbed = GetComponent<GrabDetection>().isGrabbed;

        objectSnapped = SnapLocation.GetComponent<Oculus.Interaction.SnapToLocation>().Snapped;

        if (objectSnapped)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.SetParent(kiinnike.transform);
            isSnapped = true;
        }

        if (!objectSnapped && !grabbed)
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
