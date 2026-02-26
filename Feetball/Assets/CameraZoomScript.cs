using UnityEngine;

public class CameraZoomScript : MonoBehaviour
{
    public float zoomMagnifier;

    public Camera cam;

    public float originalZoom;

    private void Start()
    {
        originalZoom = cam.orthographicSize;
    }

    public void ReturnToOriginalZoom()
    {
        Zoom(originalZoom);
    }

    public void ZoomInSlowly(float chargeAmount)
    {
        float zoomSize = originalZoom - (zoomMagnifier * chargeAmount);
        Zoom(zoomSize);
    }

    private void Zoom(float zoomSize)
    {
        cam.orthographicSize = zoomSize;
    }
}
