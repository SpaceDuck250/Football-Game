using UnityEngine;

public class PlayerZoomScript : MonoBehaviour
{
    public FootballShootScript shootScript;
    public CameraZoomScript zoomScript;

    private void Start()
    {

        shootScript.OnCharge += OnCharge;
        shootScript.OnShoot += OnShoot;
    }

    private void OnDestroy()
    {
        shootScript.OnCharge -= OnCharge;
        shootScript.OnShoot -= OnShoot;

    }

    private void OnCharge(float chargeAmount)
    {
        zoomScript.ZoomInSlowly(chargeAmount);
    }

    private void OnShoot(float power)
    {
        zoomScript.ReturnToOriginalZoom();
    }
}
