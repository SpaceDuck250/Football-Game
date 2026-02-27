using UnityEngine;
using Game;

public class GoalScoredPositionSetter : MonoBehaviour
{
    public PositionSetterScript positionSetter;

    public float waitTime;

    private void Start()
    {
        GoalLineScript.OnGoalScored += OnGoalScored;
    }

    private void OnDestroy()
    {
        GoalLineScript.OnGoalScored -= OnGoalScored;

    }

    private void OnGoalScored(Team team)
    {
        GoalLineScript.canScore = false;
        Invoke("ResetMap", waitTime);
    }

    private void ResetMap()
    {
        GoalLineScript.canScore = true;

        positionSetter.SetAllObjectPositions();

    }
}
