using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentHanged : MonoBehaviour
{
    [SerializeField] Oculus.Interaction.SnapToLocation thisObject;
    [SerializeField] GameObject tube;

    
    // Update is called once per frame
    void Update()
    {

        if (!GameManager.instance.platformDisinfected && thisObject.Snapped)
        {
            tube.SetActive(true);
            GameManager.instance.hangedBloodBag = true;
        }

        else if (GameManager.instance.State == GameManager.GameState.Insertion && thisObject.Snapped && GameManager.instance.previousState != GameManager.GameState.Disinfect)
        {
            tube.SetActive(true);
            GameManager.instance.hangedBloodBag = true;
        }     
    }
}
