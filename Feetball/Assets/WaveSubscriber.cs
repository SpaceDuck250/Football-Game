using UnityEngine;

public class WaveSubscriber : MonoBehaviour
{
    public MovementChecker movementChecker;
    public OscillatorScript oscillatorScript;

    public FootballShootScript shootScript;

    private void Start()
    {
        movementChecker.OnMove += OnMove;
        movementChecker.OnStopMove += OnStopMove;
        shootScript.OnShoot += OnShoot;
    }

    private void OnDestroy()
    {
        movementChecker.OnMove -= OnMove;
        movementChecker.OnStopMove -= OnStopMove;
        shootScript.OnShoot -= OnShoot;
    }

    private void OnStopMove()
    {
        oscillatorScript.ActivateWaves(false);

    }

    private void OnMove()
    {
        oscillatorScript.ActivateWaves(true);
    }

    private void OnShoot(float obj)
    {
        oscillatorScript.CreateWaveCircle();
    }


}
