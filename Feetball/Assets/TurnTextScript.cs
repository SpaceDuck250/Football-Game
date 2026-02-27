using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Game;

public class TurnTextScript : MonoBehaviour
{
    public TextMeshProUGUI turnTextComponent;

    private void Start()
    {
        TurnManagerScript.OnTurnedSwitched += OnTurnSwitched;
    }

    private void OnDestroy()
    {
        TurnManagerScript.OnTurnedSwitched -= OnTurnSwitched;

    }

    private void OnTurnSwitched(Team team)
    {


        if (team == Team.red)
        {
            turnTextComponent.text = "Turn: " + "<color=red>red</color>";
        }
        else
        {

            turnTextComponent.text = "Turn: " + "<color=blue>blue</color>";

        }
    }
}
