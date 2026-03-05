using UnityEngine;
using Game;

public class GoalScoredPositionSetter : MonoBehaviour
{
    public PositionSetterScript positionSetter;

    public float waitTime;

    private void Start()
    {
        StartTurnSetter.OnLevelReset += OnLevelReset;
    }

    private void OnDestroy()
    {

        StartTurnSetter.OnLevelReset -= OnLevelReset;

    }

    private void OnLevelReset(Team team)
    {
        positionSetter.SetAllObjectPositions();

    }

}
