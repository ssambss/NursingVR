using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCanvas : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.instance.UpdateGameState(GameManager.GameState.GameStart);
    }
}
