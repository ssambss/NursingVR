using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NurseSounds : MonoBehaviour
{
    [SerializeField] private AudioSource nurse;
    [SerializeField] private AudioClip tutorial, recovery, recovery2, medicine, medicine2, failedEquipment, endSpeak;
    private bool medicinePlayed, medicine2Played, recovery2Played, failedEquipmentPlayed;

    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManager_OnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManager_OnGameStateChanged;
    }

    private void GameManager_OnGameStateChanged(GameManager.GameState state)
    {
        if (state == GameManager.GameState.TutorialRoom)
        {
            StartCoroutine(WaitForSeconds());
        }

        if (state == GameManager.GameState.GameStart)
        {
            nurse.Stop();
            nurse.PlayOneShot(recovery);
        }

        if (state == GameManager.GameState.MonitorPatient && !recovery2Played)
        {
            recovery2Played = true;
            nurse.PlayOneShot(recovery2);
        }

        if (state == GameManager.GameState.Disinfect && !medicinePlayed)
        {
            nurse.Stop();
            medicinePlayed = true;
            nurse.PlayOneShot(medicine);
        }

        if (state == GameManager.GameState.Insertion && !medicine2Played)
        {
            medicine2Played = true;
            nurse.PlayOneShot(medicine2);
        }

        if (state == GameManager.GameState.FailedEquipment && !failedEquipmentPlayed)
        {
            failedEquipmentPlayed = true;
            nurse.PlayOneShot(failedEquipment);
        }

        if (state == GameManager.GameState.Results)
        {
            nurse.PlayOneShot(endSpeak);
        }

    }

    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(3);
        nurse.PlayOneShot(tutorial);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
