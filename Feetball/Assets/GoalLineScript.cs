using UnityEngine;
using System;
using Game;

public class GoalLineScript : MonoBehaviour
{
    public Team ownerTeam;

    public static event Action<Team> OnGoalScored;

    public static bool canScore;

    private void Start()
    {
        canScore = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "GameBall")
        {
            return;
        }

        Rigidbody2D gameBallRb = collision.gameObject.GetComponent<Rigidbody2D>();
        Vector2 gameBallMoveDirection = gameBallRb.linearVelocity;

        if (CheckIfBallCrossedLine(gameBallMoveDirection))
        {
            OnGoalScored?.Invoke(ownerTeam);
        }
    }

    private bool CheckIfBallCrossedLine(Vector2 gameBallMoveDirection)
    {
        if (!canScore)
        {
            return false;
        }

        Vector2 goalLineUp = transform.up;

        float dotProduct = Vector2.Dot(gameBallMoveDirection, goalLineUp);

        if (dotProduct < 0)
        {
            return true;
        }

        return false;
    }
}

namespace Game
{
    public enum Team
    {
        red,
        blue
    }
}