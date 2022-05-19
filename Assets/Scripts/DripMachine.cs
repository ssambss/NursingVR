using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DripMachine : MonoBehaviour
{
    public void CheckedDripMachine()
    {
        if (GameManager.instance.State == GameManager.GameState.Insertion)
        {
            GameManager.instance.checkedDripMachine = true;
            GameManager.instance.UpdateGameState(GameManager.GameState.MonitorPatient);
        }
    }
}
