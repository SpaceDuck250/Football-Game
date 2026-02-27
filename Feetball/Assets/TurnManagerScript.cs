using UnityEngine;
using System;
using Game;

public class TurnManagerScript : MonoBehaviour
{
    public static System.Action OnSwitchTurn;
    public static Action<Team> OnTurnedSwitched; // After switch

    public Team teamTurn;


    private void Start()
    {
        OnSwitchTurn += OnTurnChangeFunction;
    }

    private void OnDestroy()
    {
        OnSwitchTurn -= OnTurnChangeFunction;

    }

    private void OnTurnChangeFunction()
    {
        SwitchTurn();
    }

    private void SwitchTurn()
    {
        teamTurn = teamTurn == Team.red ? Team.blue : Team.red;
        OnTurnedSwitched?.Invoke(teamTurn);
        //playerTurnObj = playerTurnObj == player1 ? player2 : player1;
    }


}
