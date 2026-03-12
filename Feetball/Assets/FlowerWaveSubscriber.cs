using UnityEngine;

public class FlowerWaveSubscriber : MonoBehaviour
{
    public MovementChecker movementChecker;
    public OscillatorScript oscillatorScript;

    private void Start()
    {
        movementChecker.OnMove += OnMove;
        movementChecker.OnStopMove += OnStopMove;
    }

    private void OnDestroy()
    {
        movementChecker.OnMove -= OnMove;
        movementChecker.OnStopMove -= OnStopMove;
    }

    private void OnStopMove()
    {
        oscillatorScript.ActivateWaves(false);

    }

    private void OnMove()
    {
        oscillatorScript.ActivateWaves(true);
    }
}
