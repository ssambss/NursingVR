using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monitor : MonoBehaviour
{
    public void CheckedMonitor()
    {
        if (GameManager.instance.State == GameManager.GameState.MonitorPatient)
        {
            GameManager.instance.monitoredPatient = true;
            GameManager.instance.UpdateGameState(GameManager.GameState.Results);
        }
    }
}
