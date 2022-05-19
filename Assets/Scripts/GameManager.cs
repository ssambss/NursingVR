using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TeleporttausScribu tp;
    [SerializeField] WaterFlowScript checkWaterFlow;
    [SerializeField] PlatformCollision hasCollided;
    public static GameManager instance;

    public GameState State;
    public GameState nextState;
    public GameState previousState;

    public static event Action<GameState> OnGameStateChanged;
    public bool hasWashed;
    public bool checkedPC;
    public bool platformDisinfected;
    public bool correctBag;
    public bool correctLine;
    public bool wrongBag;
    public bool wrongLine;
    public bool waitsToGivePoints;
    public bool hangedBloodBag;
    public bool checkedDripMachine;
    public bool monitoredPatient;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UpdateGameState(GameState.TutorialRoom);
    }

    public void UpdateGameState(GameState newState)
    {
        previousState = State;
        State = newState;

        switch (newState)
        {
            case GameState.TutorialRoom:
                HandleTutorialRoom();
                break;
            case GameState.GameStart:
                HandleGameStart();
                break;
            case GameState.WashHands:
                HandleWashing();
                break;
            case GameState.CheckPC:
                HandlePC();
                break;
            case GameState.Disinfect:
                HandleDisinfect();
                break;
            case GameState.Equipment:
                HandleEquipment();
                break;
            case GameState.Insertion:
                HandleInsertion();
                break;
            case GameState.MonitorPatient:
                HandleMonitoring();
                break;
            case GameState.Results:
                HandleResults();
                break;
            case GameState.FailedEquipment:
                HandleFailedEquipment();
                break;
            case GameState.Failed:
                HandleFailed();
                break;
                
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void HandleFailedEquipment()
    {
        UpdateGameState(previousState);
    }

    private void HandleFailed()
    {
        //Voice line t‰h‰n
        Debug.Log("Current State: " + State);
        nextState = GameState.WashHands;
        UpdateGameState(GameState.WashHands);
    }

    private void HandleResults()
    {
        if (!platformDisinfected)
        {
            ScoreSystem.instance.IncrementScore();
            Debug.Log("results 1");
        }

        else
        {
            Debug.Log("results 2");
            ScoreSystem.instance.IncrementScoreBy2();
        }
        tp.TeleporttausTutorialResults();
    }

    private void HandleMonitoring()
    {
        if (!platformDisinfected)
        {
            ScoreSystem.instance.IncrementScore();
            Debug.Log("monitored 1");
        }

        else
        {
            Debug.Log("monitored 2");
            ScoreSystem.instance.IncrementScoreBy2();
        }
        Debug.Log("Current State: " + State);
        nextState = GameState.Results;
    }

    private void HandleInsertion()
    {   
        if (previousState != GameState.Equipment || waitsToGivePoints)
        {
            ScoreSystem.instance.IncrementScore();
            Debug.Log("insertion 1");
        }

        else
        {
            Debug.Log("insertion 2");
            ScoreSystem.instance.IncrementScoreBy2();
        }
        Debug.Log("Current State: " + State);
        nextState = GameState.MonitorPatient;
    }

    private void HandleEquipment()
    {

        if (platformDisinfected && previousState == GameState.CheckPC)
        {
            Debug.Log("Equipment 1");
            ScoreSystem.instance.IncrementScore();
        }

        else if (platformDisinfected && previousState != GameState.WashHands)
        {
            ScoreSystem.instance.IncrementScoreBy2();
            Debug.Log("t‰‰ vitun paska 2");
        }

        else if (previousState == GameState.WashHands)
        {
            Debug.Log("Equipment 1");
            ScoreSystem.instance.IncrementScore();
        }
        Debug.Log("Current State: " + State);
        nextState = GameState.Insertion;
    }

    private void HandleDisinfect()
    {
        if (previousState == GameState.WashHands)
        {
            ScoreSystem.instance.IncrementScore();
            Debug.Log("disinfect 1");
        }

        else if (previousState == GameState.CheckPC)
        {
            ScoreSystem.instance.IncrementScoreBy2();
            Debug.Log("disinfect 2");
        }
        Debug.Log("Current State: " + State);
        nextState = GameState.Equipment;
    }

    private void HandlePC()
    {
        if (platformDisinfected)
        {
            ScoreSystem.instance.IncrementScore();
            Debug.Log("pc 1");
        }

        else if (!platformDisinfected)
        {
            ScoreSystem.instance.IncrementScoreBy2();
            Debug.Log("pc 2");
        }
        Debug.Log("Current State: " + State);
        nextState = GameState.Disinfect;
    }

    private void HandleWashing()
    {
        Debug.Log("Current State: " + State);
        nextState = GameState.CheckPC;
    }

    private void HandleGameStart()
    {
        Debug.Log("Current State: " + State);
        ScoreSystem.instance.ResetScore();
        tp.TeleporttausStart();
        UpdateGameState(GameState.WashHands);
    }

    private void HandleTutorialRoom()
    {
        Debug.Log("Current State: " + State);
        nextState = GameState.GameStart;
        tp.TeleporttausTutorialResults();
    }

    public enum GameState
    {
        TutorialRoom,
        GameStart,
        WashHands,
        CheckPC,
        Disinfect,
        Equipment,
        Insertion,
        MonitorPatient,
        Results,
        FailedEquipment,
        Failed
    }
}
