using UnityEngine;
using Game;
using UnityEngine.UI;
using TMPro;

public class ScoreBoardScript : MonoBehaviour
{
    public string scoreBoardText;
    public Team team;

    public int score;

    public TextMeshProUGUI scoreTextComponent;

    private void Start()
    {
        score = 0;

        GoalLineScript.OnGoalScored += OnGoalScored;
    }

    private void OnGoalScored(Team team)
    {
        if (this.team == team)
        {
            return;
        }

        SetNewScore();
    }

    private void SetNewScore()
    {
        score++;
        scoreTextComponent.text = scoreBoardText + score;
    }

}
