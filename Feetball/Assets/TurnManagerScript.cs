using UnityEngine;
using System;
using Game;

public class TurnManagerScript : MonoBehaviour
{
    public static System.Action OnSwitchTurn;
    public static Action<Team> OnTurnedSwitched; // After switch

    public Team teamTurn;

    private bool goalScored = false;


    private void Start()
    {
        OnSwitchTurn += OnTurnChangeFunction;
        StartTurnSetter.OnLevelReset += OnLevelReset;

    }

    private void OnDestroy()
    {
        OnSwitchTurn -= OnTurnChangeFunction;
        StartTurnSetter.OnLevelReset -= OnLevelReset;

    }

    private void OnTurnChangeFunction()
    {
        AlternateTurns();

    }

    private void AlternateTurns()
    {
        teamTurn = teamTurn == Team.red ? Team.blue : Team.red;
        OnTurnedSwitched?.Invoke(teamTurn);
        //playerTurnObj = playerTurnObj == player1 ? player2 : player1;
    }

    private void OnLevelReset(Team team)
    {
        teamTurn = team;

        OnTurnedSwitched?.Invoke(teamTurn);
    }


}
