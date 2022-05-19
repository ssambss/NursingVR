using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongEquipmentTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject.CompareTag("WrongLine"))
        {
            GameManager.instance.wrongLine = true;
            GameManager.instance.UpdateGameState(GameManager.GameState.FailedEquipment);
        }

        else if (other.gameObject.CompareTag("CorrectLine"))
        {
            GameManager.instance.wrongBag = true;
            GameManager.instance.UpdateGameState(GameManager.GameState.FailedEquipment);
        }
    }
}
