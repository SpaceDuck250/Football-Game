using UnityEngine;
using System;
using Game;

public class StartTurnSetter : MonoBehaviour
{
    public static Action<Team> OnLevelReset;
    public Team recentlyScoredOnTeam;

    public float waitTime;

    private void Start()
    {
        GoalLineScript.OnGoalScored += OnGoalScored;
    }

    private void OnDestroy()
    {
        GoalLineScript.OnGoalScored -= OnGoalScored;
    }

    private void OnGoalScored(Team teamScoredOn)
    {
        recentlyScoredOnTeam = teamScoredOn;
        GoalLineScript.canScore = false;

        Invoke("ResetMap", waitTime);
    }

    private void ResetMap()
    {
        OnLevelReset?.Invoke(recentlyScoredOnTeam);
        GoalLineScript.canScore = true;

    }

}
